using MediatR;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace hris.Security.Application.Query.Handler
{

    public class ValidateTokenQueryHandler : IRequestHandler<ValidateTokenQuery, ClaimsPrincipal?>
    {
        private readonly string _secretKey;

        public ValidateTokenQueryHandler(IConfiguration configuration)
        {
            _secretKey = configuration["JWT_SECRET"]
                          ?? throw new ArgumentNullException("JWT_SECRET configuration is missing.");
        }

        public async Task<ClaimsPrincipal?> Handle(ValidateTokenQuery request, CancellationToken cancellationToken)
        {
            var token = request.Token;
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
                var principal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);
                return principal;
            }
            catch
            {
                return null;
            }
        }
    }
}
