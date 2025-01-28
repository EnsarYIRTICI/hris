using hris.Staff.Domain.Entities;
using MediatR;

namespace hris.Staff.Application.Query
{
    public class GetAllEmployeesQuery : IRequest<List<Employee>>
    {
        public int Offset { get; }

        public GetAllEmployeesQuery(int offset)
        {
            Offset = offset;
        }
    }
}

