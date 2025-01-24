using hris.Staff.Domain.Entities;
using MediatR;

namespace hris.Staff.Application.Command
{
    public class CreateEmployeeCommand : IRequest<Employee>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tckn { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Password { get; set; }
        public int PositionId { get; set; }

        public List<PhoneNumberCommand> PhoneNumbers { get; set; } = new List<PhoneNumberCommand>();
        public List<EmailCommand> Emails { get; set; } = new List<EmailCommand>();
    }

    public class PhoneNumberCommand
    {
        public string PhoneNumber { get; set; }
        public int PhoneTypeId { get; set; }
    }

    public class EmailCommand
    {
        public string Email { get; set; }
        public int EmailTypeId { get; set; }
    }
}
