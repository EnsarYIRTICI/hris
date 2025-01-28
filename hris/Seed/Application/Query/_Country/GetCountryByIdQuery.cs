using hris.Seed.Domain.Entities;
using MediatR;

namespace hris.Seed.Application.Query._Country
{
    public class GetCountryByIdQuery : IRequest<Country>
    {
        public int Id { get; }

        public GetCountryByIdQuery(int id)
        {
            Id = id;
        }
    }
}
