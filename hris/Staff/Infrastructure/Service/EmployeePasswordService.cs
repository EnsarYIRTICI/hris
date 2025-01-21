using hris.Staff.Application.Interface;
using System.Security.Cryptography;

namespace hris.Staff.Infrastructure.Service
{
    public class EmployeePasswordService : IEmployeePasswordService
    {
        public bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var hmac = new HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(storedHash);
            }
        }
    }
}
