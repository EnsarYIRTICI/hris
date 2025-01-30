using hris.Seed.Application.Dto._Department;
using hris.Seed.Domain.Entities;
using MediatR;

namespace hris.Seed.Application.Query._Department
{
    public class GetAllDepartmentsQuery : IRequest<List<DepartmentSummaryDto>>
    {
    }
}
