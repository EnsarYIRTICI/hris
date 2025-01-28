using MediatR;
using System.Security.Cryptography;
using System.Text;

namespace hris.Staff.Application.Query._EmployeePassword.Handler
{
    public class VerifyPasswordHashQueryHandler : IRequestHandler<VerifyPasswordHashQuery, bool>
    {
        public async Task<bool> Handle(VerifyPasswordHashQuery request, CancellationToken cancellationToken)
        {
            using (var hmac = new HMACSHA512(request.StoredSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));
                return await Task.FromResult(computedHash.SequenceEqual(request.StoredHash));
            }
        }
    }
}
