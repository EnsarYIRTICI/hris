using hris.Database;
using hris.Seed.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hris.Seed.Application.Query._Position.Handler
{
    public class GetPositionsByDepartmentIdQueryHandler : IRequestHandler<GetPositionsByDepartmentIdQuery, List<Position>>
    {
        private readonly AppDbContext _context;

        public GetPositionsByDepartmentIdQueryHandler(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Position>> Handle(GetPositionsByDepartmentIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Positions
                .Where(p => p.DepartmentId == request.DepartmentId)
                .ToListAsync(cancellationToken);
        }
    }
}
