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

        [Required, MaxLength(200)]
        [EmailAddress]
        public string Email { get; set; }

        [Required, Phone, MaxLength(15)]
        public string PhoneNumber { get; set; } 

        [Required, MinLength(8)]
        public string Password { get; set; }

        [Required]
        public int EmailTypeId { get; set; } // Email türünün ID'si

        [Required]
        public int PositionId { get; set; } // Pozisyon ID'si
    }

}
