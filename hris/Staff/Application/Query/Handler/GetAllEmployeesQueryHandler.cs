using hris.Database;
using hris.Staff.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hris.Staff.Application.Query.Handler
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, List<Employee>>
    {
        private readonly AppDbContext _context;

        public GetAllEmployeesQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Employees
                .OrderBy(e => e.Id)
                .Skip(request.Offset)
                .Take(50)
                .ToListAsync(cancellationToken);
        }
    }
}
