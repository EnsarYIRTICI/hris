using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace hris.Security.Application.Command
{
    public class TokenValidator
    {
        private readonly string _secretKey;

        public TokenValidator(IConfiguration configuration)
        {
            _secretKey = configuration["JWT_SECRET"]
                          ?? throw new ArgumentNullException("JWT_SECRET configuration is missing.");
        }

        public ClaimsPrincipal? Validate(string token, out SecurityToken? validatedToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_secretKey);

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };

            try
            {
                var principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
                return principal;
            }
            catch
            {
                validatedToken = null;
                return null;
            }
        }
    }

}
