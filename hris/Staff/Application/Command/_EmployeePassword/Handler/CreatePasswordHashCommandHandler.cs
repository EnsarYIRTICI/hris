using hris.Staff.Application.Command._EmployeePassword;
using MediatR;
using System.Security.Cryptography;
using System.Text;

namespace hris.Staff.Application.Command._EmployeePassword.Handler
{
    public class CreatePasswordHashCommandHandler : IRequestHandler<CreatePasswordHashCommand, (byte[] PasswordHash, byte[] PasswordSalt)>
    {
        public async Task<(byte[] PasswordHash, byte[] PasswordSalt)> Handle(CreatePasswordHashCommand request, CancellationToken cancellationToken)
        {
            using (var hmac = new HMACSHA512())
            {
                var passwordSalt = hmac.Key;
                var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));
                return await Task.FromResult((passwordHash, passwordSalt));
            }
        }
    }
}
