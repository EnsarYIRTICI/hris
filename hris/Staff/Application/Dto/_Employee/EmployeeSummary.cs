using System.ComponentModel.DataAnnotations;

namespace hris.Staff.Application.Dto._Employee
{
    public class EmployeeSummary
    {
        public int Id { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public string Tckn { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; } 
    }
}
