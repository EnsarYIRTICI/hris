using hris.Database;
using hris.Staff.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hris.Staff.Application.Query._EmployeeEmail.Handler
{
    public class GetValidEmailByEmployeeIdQueryHandler : IRequestHandler<GetValidEmailByEmployeeIdQuery, EmployeeEmail?>
    {
        private readonly AppDbContext _context;

        public GetValidEmailByEmployeeIdQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<EmployeeEmail?> Handle(GetValidEmailByEmployeeIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.EmployeeEmails
                .FirstOrDefaultAsync(e => e.EmployeeId == request.EmployeeId && e.IsValid, cancellationToken);
        }
    }
}
