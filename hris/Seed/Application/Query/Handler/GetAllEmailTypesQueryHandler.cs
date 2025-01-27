using hris.Database;
using hris.Seed.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hris.Seed.Application.Query.Handler
{
    public class GetAllEmailTypesQueryHandler : IRequestHandler<GetAllEmailTypesQuery, List<EmailType>>
    {
        private readonly AppDbContext _context;

        public GetAllEmailTypesQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<EmailType>> Handle(GetAllEmailTypesQuery request, CancellationToken cancellationToken)
        {
            return await _context.EmailTypes.ToListAsync(cancellationToken);
        }
    }
}
