using hris.Database;
using hris.Staff.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hris.Staff.Application.Query._Employee.Handler
{
    public class SearchEmployeeQueryHandler : IRequestHandler<SearchEmployeeQuery, List<Employee>>
    {
        private readonly AppDbContext _context;

        public SearchEmployeeQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> Handle(SearchEmployeeQuery request, CancellationToken cancellationToken)
        {
            return await _context.Employees
                .Where(e =>
                    EF.Functions.Like(e.FirstName + " " + e.LastName, $"%{request.SearchQuery}%") ||
                    EF.Functions.Like(e.Tckn, $"{request.SearchQuery}%"))
                .OrderBy(e => e.Id)
                .Take(50)
                .ToListAsync(cancellationToken);
        }
    }
}
