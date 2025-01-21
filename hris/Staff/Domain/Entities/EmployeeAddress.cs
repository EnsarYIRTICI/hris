using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using hris.Seed.Domain.Entities;

namespace hris.Staff.Domain.Entities
{
    public class EmployeeAddress
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required, MaxLength(300)]
        public string AddressLine1 { get; set; } // Adres satırı 1 (örn: cadde, sokak adı)

        [MaxLength(300)]
        public string AddressLine2 { get; set; } // Adres satırı 2 (örn: apartman, daire numarası)

        [Required]
        public int CityId { get; set; } // Şehir Id'si (Foreign Key)

        public City City { get; set; } // Şehir ile İlişki

        [MaxLength(20)]
        public string PostalCode { get; set; } // Posta Kodu
    }
}
