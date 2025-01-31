using hris.Database;
using hris.Staff.Application.Dto._Employee;
using hris.Staff.Application.Query._Employee;
using hris.Staff.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hris.Staff.Application.Query._Employee.Handler
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, List<EmployeeSummary>>
    {
        private readonly AppDbContext _context;

        public GetAllEmployeesQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeeSummary>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {

            return await _context.Employees
               .Select(e => new EmployeeSummary
               {
                   Id = e.Id,
                   FirstName = e.FirstName,
                   LastName = e.LastName,
                   Tckn = e.Tckn,
                   Email = e.Emails
                       .Where(email => email.IsValid && email.IsApproved && !email.IsDeleted)
                       .OrderBy(email => email.Id)
                       .Select(email => email.Email)
                       .FirstOrDefault() ?? "No email"
               })
               .OrderBy(e => e.Id)
               .Skip(request.Offset)
               .Take(50)
               .ToListAsync(cancellationToken);
        }
    }
}
