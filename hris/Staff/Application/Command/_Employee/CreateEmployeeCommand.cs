using hris.Staff.Application.Dto;
using hris.Staff.Domain.Entities;
using MediatR;

namespace hris.Staff.Application.Command._Employee
{
    public class CreateEmployeeCommand : IRequest<Employee>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tckn { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Password { get; set; }
        public int PositionId { get; set; }
        public List<EmailCommand> Emails { get; set; } = new List<EmailCommand>();
        public List<PhoneCommand> PhoneNumbers { get; set; } = new List<PhoneCommand>();
    }

    public class EmailCommand : IRequest<EmployeeEmail>
    {
        public string Email { get; set; }
        public int EmailTypeId { get; set; }
    }

    public class PhoneCommand : IRequest<EmployeePhoneNumber>
    {
        public string PhoneNumber { get; set; }
        public int PhoneTypeId { get; set; }
        public int CountryId { get; set; }
    }
}
