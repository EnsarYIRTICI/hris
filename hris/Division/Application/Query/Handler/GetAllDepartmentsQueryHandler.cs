using hris.Database;
using hris.Division.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hris.Division.Application.Query.Handler
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
