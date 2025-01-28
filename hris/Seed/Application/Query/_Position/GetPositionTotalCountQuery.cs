using hris.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hris.Seed.Application.Query._Position
{
    public class GetPositionTotalCountQuery : IRequest<int>
    {
    }
}
