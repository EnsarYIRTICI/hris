using hris.Database;
using hris.Seed.Application.Dto._Department;
using hris.Seed.Application.Dto._Position;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hris.Seed.Application.Query._Department.Handler
{
    public class GetDepartmentDetailsQueryHandler : IRequestHandler<GetDepartmentDetailsQuery, DepartmentDetailsDto>
    {
        private readonly AppDbContext _context;

        public GetDepartmentDetailsQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DepartmentDetailsDto> Handle(GetDepartmentDetailsQuery request, CancellationToken cancellationToken)
        {
            var department = await _context.Departments
                .Where(d => d.Id == request.DepartmentId)
                .Include(d => d.Positions)
                    .ThenInclude(p => p.EmployeePositions) 
                .Select(d => new DepartmentDetailsDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    Positions = d.Positions.Select(p => new PositionSummaryDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                        EmployeeCount = p.EmployeePositions.Count()
                    }).ToList()
                })
                .FirstOrDefaultAsync(cancellationToken);

            return department ?? throw new KeyNotFoundException("Department not found");
        }
    }
}
