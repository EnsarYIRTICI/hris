using System.ComponentModel.DataAnnotations;

namespace hris.Seed.Domain.Entities
{
    public class Country
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required, MaxLength(100)]
        public string Name { get; set; } // Ülke Adı

        public ICollection<City> Cities { get; set; } // Ülkedeki Şehirler
    }
}
