using hris.Seed.Domain.Entities;
using MediatR;

namespace hris.Seed.Application.Query
{
    public class GetAllCountriesQuery : IRequest<List<Country>>
    {
    }
}
