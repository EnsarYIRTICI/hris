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

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required, MinLength(8)]
        public string Password { get; set; }

        [Required]
        public int PositionId { get; set; }

        public List<EmailDto> Emails { get; set; } = new List<EmailDto>();

        public List<PhoneDto> PhoneNumbers { get; set; } = new List<PhoneDto>();
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
    }

}
