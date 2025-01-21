using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using hris.Staff.Domain.Entities;

namespace hris.Seed.Domain.Entities
{
    public class Bank
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required, MaxLength(100)]
        public string Name { get; set; } // Banka Adı (örn: "Ziraat Bankası", "Garanti BBVA")

        [MaxLength(50)]
        public string SwiftCode { get; set; } // Bankanın SWIFT Kodu (Opsiyonel)

        [MaxLength(200)]
        public string? Address { get; set; } // Bankanın Adresi (Opsiyonel)

        // Navigation Property
        public ICollection<EmployeeBank> EmployeeBanks { get; set; } = new List<EmployeeBank>(); // Çalışan banka hesapları ile ilişki
    }
}
