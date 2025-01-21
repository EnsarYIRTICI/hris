using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using hris.Staff.Domain.Entities;

namespace hris.Seed.Domain.Entities
{
    public class EmailType
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required, MaxLength(50)]
        public string Name { get; set; } // Tür Adı (örn: "Personal", "Work")

        public ICollection<EmployeeEmail> Emails { get; set; } = new List<EmployeeEmail>();
    }
}
