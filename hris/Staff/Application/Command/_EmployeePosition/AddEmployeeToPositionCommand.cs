using MediatR;

namespace hris.Staff.Application.Command._EmployeePosition
{
    public class AddEmployeeToPositionCommand : IRequest<bool>
    {
        public int PositionId { get; set; }
        public int EmployeeId { get; set; }

        public AddEmployeeToPositionCommand(int positionId, int employeeId)
        {
            PositionId = positionId;
            EmployeeId = employeeId;
        }
    }
}
