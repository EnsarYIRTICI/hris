using hris.Database;
using hris.Staff.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hris.Staff.Application.Query.Handler
{
    public class GetEmployeeByTcknQueryHandler : IRequestHandler<GetEmployeeByTcknQuery, Employee?>
    {
        private readonly AppDbContext _context;

        public GetEmployeeByTcknQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Employee?> Handle(GetEmployeeByTcknQuery request, CancellationToken cancellationToken)
        {
            return await _context.Employees
                .FirstOrDefaultAsync(e => e.Tckn == request.Tckn, cancellationToken);
        }
    }
}
