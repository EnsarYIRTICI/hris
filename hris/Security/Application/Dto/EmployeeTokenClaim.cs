namespace hris.Security.Application.Dto
{
    public class EmployeeTokenClaim
    {
        public string EmployeeId { get; set; }
        public DateTime? LastPasswordChange { get; set; }
    }
}
