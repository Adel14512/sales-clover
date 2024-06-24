

using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace Evaluation.UI.Authentication
{
    internal class CustomAuthenticationHandler : AuthenticationHandler<AuthenticationOptions>
    {
        private IOptionsMonitor<AuthenticationOptions> _option;
        private readonly IMemoryCache _cache;
		private readonly IConfiguration _configuration;
		private readonly ITokenService _tokenService;
		public CustomAuthenticationHandler(IOptionsMonitor<AuthenticationOptions> option, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IMemoryCache cache, IConfiguration configuration, ITokenService tokenService) : base(option, logger, encoder, clock)
		{
			_option = option;
			_cache = cache;
			_configuration = configuration;
			_tokenService = tokenService;
		}

		protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string cacheToken = string.Empty;
            string token = string.Empty;
            bool isTokenExpiredHeader = false;
            var scdae = Request.Headers["IS-TOKEN-EXPIRED"];
            
            
            string controller = Request.RouteValues.Values.First().ToString().ToLower();
            token = Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(token))
            {
                token = (string)_cache.Get("TOKEN");
                Request.Headers["Authorization"] = "Bearer " + token;
            }
            else
            {
                if (token.Contains("Bearer"))
                {
                    token = token.Replace("Bearer ", "");
                }
             
            }
           
           

            if (string.IsNullOrEmpty(token))
            {
                return AuthenticateResult.NoResult();
            }
            else
			{
				bool istokenExpired = IsTokenExpired(token);

				if (istokenExpired)
				{
					return AuthenticateResult.NoResult();

				}
				AuthenticationTicket ticket = GetTicketFromToken(token);
				if (IsTokenHas10mins(token))
				{
					ticket = CreateNewTokenTicket(token);
				}
				return AuthenticateResult.Success(ticket);
			}
			//return AuthenticateResult.NoResult();
		}

		private AuthenticationTicket CreateNewTokenTicket(string token)
		{
			string newToken = _tokenService.ExtendTokenExpiration(token);
			_cache.Set("TOKEN", newToken);
			Request.Headers["Authorization"] = newToken;
			AuthenticationTicket ticket1 = GetTicketFromToken(newToken);
			return ticket1;
		}

		private AuthenticationTicket GetTicketFromToken(string token)
		{
			var jwttoken = new JwtSecurityTokenHandler().ReadJwtToken(token);
			var identity = new ClaimsIdentity(jwttoken.Claims, Scheme.Name);
			var principal = new ClaimsPrincipal(identity);
			var ticket = new AuthenticationTicket(principal, Scheme.Name);
			return ticket;
		}

		private bool IsTokenExpired(string token)
        {
            var securityToken = new JwtSecurityToken(token);
            var expirationTime = securityToken.ValidTo;
            var currentTime = DateTime.UtcNow;
            return currentTime > expirationTime;
        }
		private bool IsTokenHas10mins(string token)
		{
			var securityToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
			var expirationTime = securityToken.ValidTo;
			var currentTime = DateTime.UtcNow;

			// Calculate the time remaining until expiration
			var timeRemaining = expirationTime - currentTime;

			// Check if the time remaining is between 0 and 10 minutes
			return timeRemaining > TimeSpan.Zero && timeRemaining <= TimeSpan.FromMinutes(10);
		}
		protected override async Task HandleChallengeAsync(AuthenticationProperties properties)
		{
			if (!Context.User.Identity.IsAuthenticated)
			{
				Response.Redirect("/Login/Index");
				return;
			}

			await base.HandleChallengeAsync(properties);
		}
		public string ExtendTokenExpiration(string existingToken)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JsonWebTokenKeys:IssuerSigningKey"]));

			// Decode the existing token without validating it
			var jwtToken = tokenHandler.ReadJwtToken(existingToken);

			// Extract the claims from the existing token
			var claims = jwtToken.Claims;

			// Create a new expiration time (current time + 20 minutes)
			var newExpiryTime = DateTime.Now.AddMinutes(20);

			// Create a new token with the same claims and new expiration time
			var newToken = new JwtSecurityToken(
				issuer: _configuration["JsonWebTokenKeys:ValidIssuer"],
				audience: _configuration["JsonWebTokenKeys:ValidAudience"],
				claims: claims,
				expires: newExpiryTime,
				signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
			);

			// Write the new token
			var tokenString = tokenHandler.WriteToken(newToken);

			// Optionally, update the memory cache entry expiration
			var options = new MemoryCacheEntryOptions().SetAbsoluteExpiration(newToken.ValidTo);

			return tokenString;
		}
	}
}
