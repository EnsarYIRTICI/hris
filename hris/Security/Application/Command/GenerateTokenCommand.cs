using MediatR;

namespace hris.Security.Application.Command
{
    public class GenerateTokenCommand : IRequest<string>
    {
        public string EmployeeId { get; set; }
        public DateTime? LastPasswordChange { get; set; }

        public GenerateTokenCommand(string employeeId, DateTime? lastPasswordChange)
        {
            EmployeeId = employeeId;
            LastPasswordChange = lastPasswordChange;
        }
    }
}
