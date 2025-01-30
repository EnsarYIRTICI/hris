using hris.Database;
using hris.Seed.Domain.Entities;
using MediatR;

namespace hris.Seed.Application.Command._Department.Handler
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, Department>
    {
        private readonly AppDbContext _context;

        public CreateDepartmentCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Department> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = new Department
            {
                Name = request.Name
            };

            foreach (var positionDto in request.Positions)
            {
                var position = new Position
                {
                    Name = positionDto.Name
                };
                department.Positions.Add(position);
            }

            _context.Departments.Add(department);
            await _context.SaveChangesAsync(cancellationToken);

            return department;
        }
    }
}
