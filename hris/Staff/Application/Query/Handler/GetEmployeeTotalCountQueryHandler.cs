using hris.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hris.Staff.Application.Query.Handler
{
    public class GetEmployeeTotalCountQueryHandler : IRequestHandler<GetEmployeeTotalCountQuery, int>
    {
        private readonly AppDbContext _context;

        public GetEmployeeTotalCountQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(GetEmployeeTotalCountQuery request, CancellationToken cancellationToken)
        {
            return await _context.Employees.CountAsync(cancellationToken);
        }
    }
}
