using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using hris.Staff.Domain.Entities;

namespace hris.Seed.Domain.Entities
{
    public class City
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required, MaxLength(100)]
        public string Name { get; set; } // Şehir Adı

        [Required]
        public int CountryId { get; set; } // Foreign Key to Country

        public Country Country { get; set; } // Ülke ile İlişki

        public ICollection<EmployeeAddress> Addresses { get; set; } // Şehirdeki Adresler
    }


}
