using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Evaluation.UI.Authentication
{
	public class TokenService: ITokenService
	{
		private readonly IConfiguration _configuration;

		public TokenService(IConfiguration configuration)
		{
			_configuration = configuration;
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
