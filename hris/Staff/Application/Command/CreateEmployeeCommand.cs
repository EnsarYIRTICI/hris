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
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public int EmailTypeId { get; set; }
        public int PositionId { get; set; }
    }
}
