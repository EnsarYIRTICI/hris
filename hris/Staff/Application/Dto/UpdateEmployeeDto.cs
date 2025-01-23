using System.ComponentModel.DataAnnotations;

namespace hris.Staff.Application.Dto
{
    public class UpdateEmployeeDto
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string FirstName { get; set; } // Çalışanın adı

        [Required, MaxLength(100)]
        public string LastName { get; set; } // Çalışanın soyadı

        [Required, MaxLength(200)]
        public string Tckn { get; set; } // T.C. Kimlik Numarası

        [Required]
        public DateTime DateOfBirth { get; set; } // Doğum tarihi
    }

}
