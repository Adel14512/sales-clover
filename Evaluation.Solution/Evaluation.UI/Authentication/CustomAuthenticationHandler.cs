

using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace Evaluation.UI.Authentication
{
    internal class CustomAuthenticationHandler : AuthenticationHandler<AuthenticationOptions>
    {
        private IOptionsMonitor<AuthenticationOptions> _option;
        private readonly IMemoryCache _cache;
        public CustomAuthenticationHandler(IOptionsMonitor<AuthenticationOptions> option, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IMemoryCache cache) : base(option, logger, encoder, clock)
        {
            _option = option;
            _cache = cache;
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
                
                if(istokenExpired)
                {
                    return AuthenticateResult.NoResult();

                }
                var jwttoken = new JwtSecurityTokenHandler().ReadJwtToken(token);
                var identity = new ClaimsIdentity(jwttoken.Claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);
                return AuthenticateResult.Success(ticket);
            }
            return AuthenticateResult.NoResult();
        }
        private bool IsTokenExpired(string token)
        {
            var securityToken = new JwtSecurityToken(token);
            var expirationTime = securityToken.ValidTo;
            var currentTime = DateTime.UtcNow;
            return currentTime > expirationTime;
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
	}
}
