using MediatR;
using System.Security.Claims;

namespace hris.Security.Application.Query
{

    public class ValidateTokenQuery : IRequest<ClaimsPrincipal?>
    {
        public string Token { get; set; }

        public ValidateTokenQuery(string token)
        {
            Token = token;
        }
    }

}
