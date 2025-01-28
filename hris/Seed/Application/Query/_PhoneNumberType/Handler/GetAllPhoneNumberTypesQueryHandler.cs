using hris.Database;
using hris.Seed.Application.Query._PhoneNumberType;
using hris.Seed.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hris.Seed.Application.Query._PhoneNumberType.Handler
{
    public class GetAllPhoneNumberTypesQueryHandler : IRequestHandler<GetAllPhoneNumberTypesQuery, List<PhoneNumberType>>
    {
        private readonly AppDbContext _context;

        public GetAllPhoneNumberTypesQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<PhoneNumberType>> Handle(GetAllPhoneNumberTypesQuery request, CancellationToken cancellationToken)
        {
            return await _context.PhoneNumberTypes.ToListAsync(cancellationToken);
        }
    }
}
