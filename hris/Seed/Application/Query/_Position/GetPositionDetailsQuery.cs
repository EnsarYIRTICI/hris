using hris.Seed.Application.Dto._Department;
using hris.Seed.Application.Dto._Position;
using MediatR;

namespace hris.Seed.Application.Query._Position
{
    public class GetPositionDetailsQuery : IRequest<PositionDetailsDto>
    {
        public int PositionId { get; set; }

        public GetPositionDetailsQuery(int positionId)
        {
            PositionId = positionId;
        }
    }
}
