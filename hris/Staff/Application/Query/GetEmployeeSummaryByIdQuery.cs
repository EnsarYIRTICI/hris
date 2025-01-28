using hris.Staff.Application.Dto;
using MediatR;

namespace hris.Staff.Application.Query
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
