using System.ComponentModel.DataAnnotations;

namespace hris.Seed.Domain.Entities
{
    public class Country
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required, MaxLength(100)]
        public string Name { get; set; } // Ülke Adı

        [Required, MaxLength(5)]
        public string PhoneCode { get; set; } // Telefon Kodu (örn: +90, +1)

        [Required, MaxLength(3)]
        public string ShortCode { get; set; } // Ülke Kısaltması (örn: TR, US, EN)

        public ICollection<City> Cities { get; set; } // Ülkedeki Şehirler
    }
}
