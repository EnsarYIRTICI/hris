using MediatR;

namespace hris.Staff.Application.Command._EmployeePassword
{
    public class CreatePasswordHashCommand : IRequest<(byte[] PasswordHash, byte[] PasswordSalt)>
    {
        public string Password { get; set; }

        public CreatePasswordHashCommand(string password)
        {
            Password = password;
        }
    }
}
