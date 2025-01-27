using hris.Database;
using hris.Seed.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hris.Seed.Application.Query.Handler
{
    public class GetPhoneNumberTypeByIdQueryHandler : IRequestHandler<GetPhoneNumberTypeByIdQuery, PhoneNumberType>
    {
        private readonly AppDbContext _context;

        public GetPhoneNumberTypeByIdQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PhoneNumberType> Handle(GetPhoneNumberTypeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.PhoneNumberTypes.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken)
                   ?? throw new KeyNotFoundException($"PhoneNumberType with ID {request.Id} not found.");
        }
    }
}
