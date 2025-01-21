using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using hris.Staff.Domain.Entities;

namespace hris.Seed.Domain.Entities
{
    public class MilitaryStatusType
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required, MaxLength(50)]
        public string Name { get; set; } // Askerlik Durum Türü (örn: "Tamamlandı", "Tecilli", "Muaf")

        public ICollection<EmployeeMilitaryStatus> EmployeeMilitaryStatuses { get; set; } = new List<EmployeeMilitaryStatus>(); // İlişkili Çalışanlar
    }
}
