using hris.Staff.Application.Dto;
using System.Security.Claims;

namespace hris.Security.Application.Dto
{
    public class EmployeeTokenValidationResult
    {
        public bool IsValid { get; set; }
        public ClaimsPrincipal Principal { get; set; }
        public EmployeeSummary Employee { get; set; }
        public string ErrorMessage { get; set; }
    }
}
