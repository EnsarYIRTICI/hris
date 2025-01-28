using hris.Staff.Application.Dto._Employee;
using MediatR;

namespace hris.Staff.Application.Query._Employee
{
    public class GetEmployeeSummaryByIdQuery : IRequest<EmployeeSummary?>
    {
        public int EmployeeId { get; }

        public GetEmployeeSummaryByIdQuery(int employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}
