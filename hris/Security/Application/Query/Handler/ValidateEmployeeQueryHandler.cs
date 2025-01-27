using hris.Staff.Application.Dto;
using hris.Staff.Application.Service;
using MediatR;

namespace hris.Security.Application.Query.Handler
{
    public class ValidateEmployeeQueryHandler : IRequestHandler<ValidateEmployeeQuery, (bool IsValid, string? ErrorMessage, EmployeeSummary? Employee)>
    {
        private readonly EmployeeService _employeeService;

        public ValidateEmployeeQueryHandler(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<(bool IsValid, string? ErrorMessage, EmployeeSummary? Employee)> Handle(ValidateEmployeeQuery request, CancellationToken cancellationToken)
        {
            var principal = request.Principal;
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
