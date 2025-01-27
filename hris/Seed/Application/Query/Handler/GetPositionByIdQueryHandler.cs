using hris.Database;
using hris.Seed.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hris.Seed.Application.Query.Handler
{
    public class GetPositionByIdQueryHandler : IRequestHandler<GetPositionByIdQuery, Position>
    {
        private readonly AppDbContext _context;

        public GetPositionByIdQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Position> Handle(GetPositionByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Positions.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken)
                   ?? throw new KeyNotFoundException($"Position with ID {request.Id} not found.");
        }
    }
}
