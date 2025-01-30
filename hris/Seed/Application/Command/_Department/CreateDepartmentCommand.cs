using hris.Seed.Application.Dto._Department;
using hris.Seed.Domain.Entities;
using MediatR;

namespace hris.Seed.Application.Command._Department
{
    public class CreateDepartmentCommand : IRequest<Department>
    {
        public string Name { get; set; }
        public List<PositionDto> Positions { get; set; } = new List<PositionDto>();

    }
}
