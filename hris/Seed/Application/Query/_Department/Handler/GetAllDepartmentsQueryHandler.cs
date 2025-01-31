using hris.Database;
using hris.Seed.Application.Dto._Department;
using hris.Seed.Application.Query._Department;
using hris.Seed.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hris.Seed.Application.Query._Department.Handler
{
    public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQuery, List<DepartmentSummaryDto>>
    {
        private readonly AppDbContext _context;

        public GetAllDepartmentsQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<DepartmentSummaryDto>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Departments
                .Select(d => new DepartmentSummaryDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    PositionsCount = d.Positions.Count(),
                    EmployeesCount = d.Positions.SelectMany(p => p.EmployeePositions).Count()
                })
                .ToListAsync(cancellationToken);
        }
    }
}
