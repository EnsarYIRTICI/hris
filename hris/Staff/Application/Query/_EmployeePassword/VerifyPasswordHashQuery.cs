using MediatR;

namespace hris.Staff.Application.Query._EmployeePassword
{
    public class VerifyPasswordHashQuery : IRequest<bool>
    {
        public string Password { get; set; }
        public byte[] StoredHash { get; set; }
        public byte[] StoredSalt { get; set; }

        public VerifyPasswordHashQuery(string password, byte[] storedHash, byte[] storedSalt)
        {
            Password = password;
            StoredHash = storedHash;
            StoredSalt = storedSalt;
        }
    }
}
