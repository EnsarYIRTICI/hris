using hris.Staff.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace hris.Staff.Application.Dto
{
    public class CreateEmployeeDto 
    {
        [Required, MaxLength(100)]
        public string FirstName { get; set; }

        [Required, MaxLength(100)]
        public string LastName { get; set; }

        [Required, MaxLength(200)]
        public string Tckn { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Required, MinLength(8)]
        public string Password { get; set; }

        [Required]
        public int PositionId { get; set; }

        [Required]
        public List<EmailDto> Emails { get; set; } = new List<EmailDto> { new EmailDto() };

        [Required]
        public List<PhoneDto> PhoneNumbers { get; set; } = new List<PhoneDto> { new PhoneDto() };

        public int DepartmentId { get; set; }
        public bool AddEmail { get; set; } = false;
        public bool AddPhone { get; set; } = false;


    }

    public class EmailDto
    {
        [Required, MaxLength(200)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public int EmailTypeId { get; set; }
    }

    public class PhoneDto
    {
        [Required, MaxLength(15)]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public int PhoneTypeId { get; set; }

        [Required]
        public int CountryId { get; set; } = 1;
    }

}
