using hris.Database;
using hris.Seed.Application.Query._Country;
using hris.Seed.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hris.Seed.Application.Query._Country.Handler
{
    public class GetCountryByIdQueryHandler : IRequestHandler<GetCountryByIdQuery, Country>
    {
        private readonly AppDbContext _context;

        public GetCountryByIdQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Country> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Countries.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken)
                   ?? throw new KeyNotFoundException($"Country with ID {request.Id} not found.");
        }
    }
}
