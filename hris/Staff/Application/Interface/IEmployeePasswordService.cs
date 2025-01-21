using hris.Staff.Domain.Entities;

namespace hris.Staff.Application.Interface
{
    public interface IEmployeePasswordService
    {
        bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt);

    }
}
