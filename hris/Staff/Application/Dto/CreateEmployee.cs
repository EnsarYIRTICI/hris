using System.ComponentModel.DataAnnotations;

namespace hris.Staff.Application.Dto
{
    public class CreateEmployeeDto
    {
        [Required, MaxLength(100)]
        public string FirstName { get; set; } // Çalışanın adı

        [Required, MaxLength(100)]
        public string LastName { get; set; } // Çalışanın soyadı

        [Required, MaxLength(200)]
        public string Tckn { get; set; } // T.C. Kimlik Numarası

        [Required]
        public DateTime DateOfBirth { get; set; } // Doğum tarihi

        [Required, MaxLength(200)]
        [EmailAddress]
        public string Email { get; set; } // Email adresi

        [Required, Phone, MaxLength(15)]
        public string PhoneNumber { get; set; } // Telefon numarası

        [Required, MinLength(8)]
        public string Password { get; set; } // Şifre

        [Required]
        public int EmailTypeId { get; set; } // Email türünün ID'si

        [Required]
        public int PositionId { get; set; } // Pozisyon ID'si
    }

}
