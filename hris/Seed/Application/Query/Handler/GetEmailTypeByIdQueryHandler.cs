using hris.Database;
using hris.Seed.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hris.Seed.Application.Query.Handler
{
    public class GetEmailTypeByIdQueryHandler : IRequestHandler<GetEmailTypeByIdQuery, EmailType>
    {
        private readonly AppDbContext _context;

        public GetEmailTypeByIdQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<EmailType> Handle(GetEmailTypeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.EmailTypes.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
                   ?? throw new KeyNotFoundException($"EmailType with ID {request.Id} not found.");
        }
    }
}
