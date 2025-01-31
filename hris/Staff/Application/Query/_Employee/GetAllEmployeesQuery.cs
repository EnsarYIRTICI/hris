using hris.Staff.Application.Dto._Employee;
using hris.Staff.Domain.Entities;
using MediatR;

namespace hris.Staff.Application.Query._Employee
{
    public class GetAllEmployeesQuery : IRequest<List<EmployeeSummary>>
    {
        public int Offset { get; }

        public GetAllEmployeesQuery(int offset)
        {
            Offset = offset;
        }
    }
}

