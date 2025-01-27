using hris.Staff.Application.Dto;
using hris.Staff.Application.Service;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace hris.Security.Application.Command
{
    public class EmployeeValidator
    {
        private readonly EmployeeService _employeeService;

        public EmployeeValidator(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<(bool IsValid, string? ErrorMessage, EmployeeSummary? Employee)> ValidateAsync(ClaimsPrincipal principal)
        {

            var employeeIdClaim = principal.FindFirst("EmployeeId")?.Value;
            if (string.IsNullOrEmpty(employeeIdClaim) || !int.TryParse(employeeIdClaim, out int employeeId))
            {
                return (false, "Token does not contain a valid EmployeeId.", null);
            }

            var employee = await _employeeService.GetSummaryByIdAsync(employeeId);
            if (employee == null)
            {
                return (false, "Employee not found in the database.", null);
            }

            if (employee.LastPasswordChange.HasValue)
            {
                var tokenLastPasswordChangeClaim = principal.FindFirst("LastPasswordChange")?.Value;
                if (string.IsNullOrEmpty(tokenLastPasswordChangeClaim) || !DateTime.TryParse(tokenLastPasswordChangeClaim, out DateTime tokenLastPasswordChange))
                {
                    return (false, "Token does not contain a valid LastPasswordChange claim.", null);
                }

                long employeeLastPasswordChangeUnix = new DateTimeOffset(employee.LastPasswordChange.Value).ToUnixTimeSeconds();
                long tokenLastPasswordChangeUnix = new DateTimeOffset(tokenLastPasswordChange).ToUnixTimeSeconds();

                if (employeeLastPasswordChangeUnix > tokenLastPasswordChangeUnix)
                {
                    return (false, "The token is invalid because the password was changed after the token was issued.", null);
                }
            }

            return (true, null, employee);
        }
    }

}
