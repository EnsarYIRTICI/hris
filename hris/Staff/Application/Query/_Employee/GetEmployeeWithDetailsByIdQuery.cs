using hris.Staff.Domain.Entities;
using MediatR;

namespace hris.Staff.Application.Query._Employee
{
    public class GetEmployeeWithDetailsByIdQuery : IRequest<Employee?>
    {
        public int EmployeeId { get; }

        public GetEmployeeWithDetailsByIdQuery(int employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}
