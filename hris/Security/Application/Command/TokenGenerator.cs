using hris.Security.Application.Dto;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace hris.Security.Application.Command
{
    public class TokenGenerator
    {
        private readonly string _secretKey;
        private readonly int _tokenLifetimeInDays;

        public TokenGenerator(IConfiguration configuration)
        {
            _secretKey = configuration["JWT_SECRET"]
                        ?? throw new ArgumentNullException("JWT_SECRET configuration is missing.");

            _tokenLifetimeInDays = int.Parse(configuration["TokenLifetimeInDays"] ?? "1");
        }


        public string Generate(EmployeeTokenClaim tokenData)
        {
            if (tokenData == null)
                throw new ArgumentNullException(nameof(tokenData));

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_secretKey);

            var claims = new[]
            {
            new Claim("EmployeeId", tokenData.EmployeeId),
            new Claim("LastPasswordChange", tokenData.LastPasswordChange?.ToString() ?? string.Empty)
        };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(_tokenLifetimeInDays),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }



}
