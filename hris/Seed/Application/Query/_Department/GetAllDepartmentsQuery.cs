using hris.Seed.Domain.Entities;
using MediatR;

namespace hris.Seed.Application.Query._Department
{
    public class GetAllDepartmentsQuery : IRequest<List<Department>>
    {
    }
}
