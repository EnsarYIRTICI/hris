using hris.Seed.Domain.Entities;
using MediatR;

namespace hris.Seed.Application.Query._Country
{
    public class GetAllCountriesQuery : IRequest<List<Country>>
    {
    }
}
