using hris.Division.Domain.Entities;
using MediatR;

namespace hris.Division.Application.Query
{
    public class GetAllDepartmentsQuery : IRequest<List<Department>>
    {
    }
}
