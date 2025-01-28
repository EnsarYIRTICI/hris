using hris.Seed.Domain.Entities;
using MediatR;

namespace hris.Seed.Application.Query._Position
{
    public class GetPositionByIdQuery : IRequest<Position>
    {
        public int Id { get; }

        public GetPositionByIdQuery(int id)
        {
            Id = id;
        }
    }
}
