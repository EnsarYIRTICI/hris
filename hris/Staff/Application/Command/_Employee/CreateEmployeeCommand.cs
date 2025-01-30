using hris.Staff.Application.Dto;
using hris.Staff.Application.Dto._Employee;
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
        public List<EmailDto> Emails { get; set; } = new List<EmailDto>();
        public List<PhoneDto> PhoneNumbers { get; set; } = new List<PhoneDto>();
    }

}
