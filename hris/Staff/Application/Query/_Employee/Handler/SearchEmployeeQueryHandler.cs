using hris.Database;
using hris.Staff.Application.Dto._Employee;
using hris.Staff.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hris.Staff.Application.Query._Employee.Handler
{
    public class SearchEmployeeQueryHandler : IRequestHandler<SearchEmployeeQuery, List<EmployeeSummary>>
    {
        private readonly AppDbContext _context;

        public SearchEmployeeQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeeSummary>> Handle(SearchEmployeeQuery request, CancellationToken cancellationToken)
        {
            return await _context.Employees
                .Where(e =>
                    EF.Functions.Like(e.FirstName + " " + e.LastName, $"%{request.SearchQuery}%") ||
                    EF.Functions.Like(e.Tckn, $"{request.SearchQuery}%"))
                .OrderBy(e => e.Id)
                .Take(50)
                .Select(e => new EmployeeSummary
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Tckn = e.Tckn,
                    DateOfBirth = e.DateOfBirth,
                    Email = e.Emails
                        .Where(email => email.IsValid && email.IsApproved && !email.IsDeleted)
                        .OrderBy(email => email.Id)
                        .Select(email => email.Email)
                        .FirstOrDefault() ?? "No email"
                })
                .ToListAsync(cancellationToken);
        }
    }
}
