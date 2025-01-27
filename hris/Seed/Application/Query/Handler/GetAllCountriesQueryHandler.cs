using hris.Database;
using hris.Seed.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hris.Seed.Application.Query.Handler
{
    public class GetAllCountriesQueryHandler : IRequestHandler<GetAllCountriesQuery, List<Country>>
    {
        private readonly AppDbContext _context;

        public GetAllCountriesQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Country>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Countries.ToListAsync(cancellationToken);
        }
    }
}
