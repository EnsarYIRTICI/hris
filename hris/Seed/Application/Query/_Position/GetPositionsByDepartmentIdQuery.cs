using hris.Seed.Domain.Entities;
using MediatR;

namespace hris.Seed.Application.Query._Position
{
    public class GetPositionsByDepartmentIdQuery : IRequest<List<Position>>
    {
        public int DepartmentId { get; set; }

        public GetPositionsByDepartmentIdQuery(int departmentId)
        {
            DepartmentId = departmentId;
        }
    }
}
