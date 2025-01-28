using hris.Seed.Domain.Entities;
using MediatR;

namespace hris.Seed.Application.Query._PhoneNumberType
{
    public class GetAllPhoneNumberTypesQuery : IRequest<List<PhoneNumberType>>
    {
    }
}
