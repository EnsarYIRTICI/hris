using Microsoft.Extensions.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using hris.Staff.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using hris.Staff.Application.Service;
using hris.Security.Application.Dto;
using hris.Database;
using hris.Security.Domain.Exceptions;

namespace hris.Security.Application.Service
{
    public class TokenService
    {
        private readonly string _secretKey;
        private readonly AppDbContext _dbContext;
        private readonly EmployeeService _employeeService;

        public TokenService(AppDbContext dbContext, IConfiguration configuration, EmployeeService employeeService)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _secretKey = configuration["JWT_SECRET"]
                          ?? throw new JWTSecretMissingException();

            _employeeService = employeeService ?? throw new ArgumentNullException();
        }



        public string GenerateToken(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_secretKey);

            var claims = new[]
            {
                new Claim("EmployeeId", employee.Id.ToString()),
                new Claim("LastPasswordChange", employee.LastPasswordChange.ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        public async Task<TokenValidationEmployeeResult> ValidateToken(string token)
        {
            var result = new TokenValidationEmployeeResult();

            try
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

                result.Principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

                var employeeIdClaim = result.Principal.FindFirst("EmployeeId")?.Value;

                if (string.IsNullOrEmpty(employeeIdClaim) || !int.TryParse(employeeIdClaim, out int employeeId))
                {
                    result.ErrorMessage = "Token does not contain a valid EmployeeId.";
                    result.IsValid = false;
                    return result;
                }

                result.Employee = await _employeeService.GetSummaryByIdAsync(employeeId);

                if (result.Employee == null)
                {
                    result.ErrorMessage = "Employee not found in the database.";
                    result.IsValid = false;
                    return result;
                }

                if (result.Employee.LastPasswordChange != null && result.Employee.LastPasswordChange.HasValue)
                {
                    var jwtToken = validatedToken as JwtSecurityToken;
                    var tokenLastPasswordChange = jwtToken?.Claims.FirstOrDefault(c => c.Type == "LastPasswordChange")?.Value;

                    if (string.IsNullOrEmpty(tokenLastPasswordChange) || !DateTime.TryParse(tokenLastPasswordChange, out DateTime tokenLastPasswordChangeDate))
                    {
                        result.ErrorMessage = "Token does not contain a valid LastPasswordChange claim.";
                        result.IsValid = false;
                        return result;
                    }

                    var lastPasswordChangeUnix = new DateTimeOffset(result.Employee.LastPasswordChange.Value).ToUnixTimeSeconds();
                    var tokenLastPasswordChangeUnix = new DateTimeOffset(tokenLastPasswordChangeDate).ToUnixTimeSeconds();

                    if (lastPasswordChangeUnix > tokenLastPasswordChangeUnix)
                    {
                        result.ErrorMessage = "The token is invalid because the password was changed after the token was issued.";
                        result.IsValid = false;
                        return result;
                    }
                }

                result.IsValid = true;
                return result;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = $"An error occurred while validating the token: {ex.Message}";
                result.IsValid = false;
                return result;
            }
        }

    }
}
