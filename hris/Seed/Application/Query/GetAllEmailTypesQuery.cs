using hris.Seed.Domain.Entities;
using MediatR;

namespace hris.Seed.Application.Query
{
    public class GetAllEmailTypesQuery : IRequest<List<EmailType>>
    {
    }
}
