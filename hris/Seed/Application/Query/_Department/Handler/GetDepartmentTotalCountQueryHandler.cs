using hris.Database;
using hris.Seed.Application.Query._Department;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hris.Seed.Application.Query._Department.Handler
{
    public class GetDepartmentTotalCountQueryHandler : IRequestHandler<GetDepartmentTotalCountQuery, int>
    {
        private readonly AppDbContext _context;

        public GetDepartmentTotalCountQueryHandler(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> Handle(GetDepartmentTotalCountQuery request, CancellationToken cancellationToken)
        {
            return await _context.Departments.CountAsync(cancellationToken);
        }
    }
}
