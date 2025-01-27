using hris.Seed.Domain.Entities;
using MediatR;

namespace hris.Seed.Application.Query
{
    public class GetPhoneNumberTypeByIdQuery : IRequest<PhoneNumberType>
    {
        public int Id { get; }

        public GetPhoneNumberTypeByIdQuery(int id)
        {
            Id = id;
        }
    }
}
