using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using hris.Staff.Domain.Entities;

namespace hris.Seed.Domain.Entities
{
    public class MaritalStatusType
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required, MaxLength(50)]
        public string Name { get; set; } // Medeni Durum Türü (örn: "Evli", "Bekar", "Dul")

        public ICollection<EmployeeMaritalStatus> EmployeeMaritalStatuses { get; set; } = new List<EmployeeMaritalStatus>(); // İlişkili Çalışanlar
    }
}
