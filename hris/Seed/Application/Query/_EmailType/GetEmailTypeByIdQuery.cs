using hris.Seed.Domain.Entities;
using MediatR;

namespace hris.Seed.Application.Query._EmailType
{
    public class GetEmailTypeByIdQuery : IRequest<EmailType>
    {
        public int Id { get; }

        public GetEmailTypeByIdQuery(int id)
        {
            Id = id;
        }
    }
}
