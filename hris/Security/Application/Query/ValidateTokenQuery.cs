using hris.Staff.Application.Dto;
using MediatR;
using System.Security.Claims;

namespace hris.Security.Application.Query
{
    public class ValidateEmployeeQuery : IRequest<(bool IsValid, string? ErrorMessage, EmployeeSummary? Employee)>
    {
        public ClaimsPrincipal Principal { get; set; }

        public ValidateEmployeeQuery(ClaimsPrincipal principal)
        {
            Principal = principal;
        }
    }
}
