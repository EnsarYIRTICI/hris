using MediatR;
using System.Security.Claims;

namespace hris.Security.Application.Command
{
    public class GenerateTokenCommand : IRequest<string>
    {

        public List<Claim> Claims { get; set; }

        public GenerateTokenCommand(List<Claim> claims)
        {
            Claims = claims;
        }
    }
}
