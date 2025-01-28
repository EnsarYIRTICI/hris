using hris.Database;
using hris.Staff.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hris.Staff.Application.Query.Handler
{
    public class GetEmployeeWithDetailsByIdQueryHandler : IRequestHandler<GetEmployeeWithDetailsByIdQuery, Employee?>
    {
        private readonly AppDbContext _context;

        public GetEmployeeWithDetailsByIdQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Employee?> Handle(GetEmployeeWithDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Employees
                .Include(e => e.Passwords)
                .Include(e => e.Emails)
                .Include(e => e.Addresses)
                .Include(e => e.PhoneNumbers)
                .Include(e => e.Banks)
                .Include(e => e.Educations)
                .Include(e => e.Relatives)
                .Include(e => e.Positions)
                .Include(e => e.Documents)
                .FirstOrDefaultAsync(e => e.Id == request.EmployeeId, cancellationToken);
        }
    }
}
