using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using hris.Seed.Domain.Entities;

namespace hris.Staff.Domain.Entities
{
    public class EmployeeMilitaryStatus
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required]
        public int EmployeeId { get; set; } // Foreign Key to Employee

        [Required]
        public int MilitaryStatusTypeId { get; set; } // Foreign Key to MilitaryStatusType

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; } // Çalışan ile ilişki

        [ForeignKey("MilitaryStatusTypeId")]
        public MilitaryStatusType MilitaryStatusType { get; set; } // Askerlik Durum Türü ile ilişki
    }
}
