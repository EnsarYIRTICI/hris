using hris.Seed.Domain.Entities;
using MediatR;

namespace hris.Seed.Application.Query._EmailType
{
    public class GetAllEmailTypesQuery : IRequest<List<EmailType>>
    {
    }
}
