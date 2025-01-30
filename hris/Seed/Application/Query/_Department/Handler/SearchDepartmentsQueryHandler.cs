using hris.Database;
using hris.Seed.Application.Dto._Department;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hris.Seed.Application.Query._Department.Handler
{
    public class SearchDepartmentsQueryHandler : IRequestHandler<SearchDepartmentsQuery, List<DepartmentSummaryDto>>
    {
        private readonly AppDbContext _context;

        public SearchDepartmentsQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<DepartmentSummaryDto>> Handle(SearchDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var searchTerm = request.SearchTerm?.ToLower().Trim() ?? "";

            return await _context.Departments
                .Where(d => d.Name.ToLower().Contains(searchTerm)) 
                .Select(d => new DepartmentSummaryDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    PositionsCount = d.Positions.Count()
                })
                .ToListAsync(cancellationToken);
        }
    }
}
