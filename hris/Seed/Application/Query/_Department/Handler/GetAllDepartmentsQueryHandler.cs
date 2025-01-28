using hris.Database;
using hris.Seed.Application.Query._Department;
using hris.Seed.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hris.Seed.Application.Query._Department.Handler
{
    public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQuery, List<Department>>
    {
        private readonly AppDbContext _context;

        public GetAllDepartmentsQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Departments.ToListAsync(cancellationToken);
        }
    }
}
