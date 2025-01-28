using hris.Staff.Domain.Entities;
using MediatR;

namespace hris.Staff.Application.Query
{
    public class GetValidEmailByEmployeeIdQuery : IRequest<EmployeeEmail?>
    {
        public int EmployeeId { get; }

        public GetValidEmailByEmployeeIdQuery(int employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}
