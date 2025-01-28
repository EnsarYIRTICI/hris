using hris.Security.Application.Query;
using MediatR;
using System.Security.Claims;
using hris.Staff.Application.Query;
using hris.Staff.Application.Query._Employee;
using hris.Staff.Application.Dto._Employee;

namespace hris.Security.Application.Query.Handler
{
    public class ValidateEmployeeQueryHandler : IRequestHandler<ValidateEmployeeQuery, (bool IsValid, string? ErrorMessage, EmployeeSummary? Employee)>
    {
        private readonly IMediator _mediator;

        public ValidateEmployeeQueryHandler(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<(bool IsValid, string? ErrorMessage, EmployeeSummary? Employee)> Handle(ValidateEmployeeQuery request, CancellationToken cancellationToken)
        {
            var principal = request.Principal;

            // EmployeeId claim'ini kontrol et
            var employeeIdClaim = principal.FindFirst("EmployeeId")?.Value;
            if (string.IsNullOrEmpty(employeeIdClaim) || !int.TryParse(employeeIdClaim, out int employeeId))
            {
                return (false, "Token does not contain a valid EmployeeId.", null);
            }

            // Çalışan özetini MediatR üzerinden getir
            var employee = await _mediator.Send(new GetEmployeeSummaryByIdQuery(employeeId), cancellationToken);
            if (employee == null)
            {
                return (false, "Employee not found in the database.", null);
            }

            // LastPasswordChange kontrolü
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

            // Başarılı doğrulama
            return (true, null, employee);
        }
    }
}
