using hris.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hris.Seed.Application.Query._Position.Handler
{
    public class GetPositionTotalCountQueryHandler : IRequestHandler<GetPositionTotalCountQuery, int>
    {
        private readonly AppDbContext _context;

        public GetPositionTotalCountQueryHandler(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> Handle(GetPositionTotalCountQuery request, CancellationToken cancellationToken)
        {
            return await _context.Positions.CountAsync(cancellationToken);
        }
    }
}
