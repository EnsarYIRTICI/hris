using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using hris.Seed.Domain.Entities;

namespace hris.Staff.Domain.Entities
{
    public class EmployeeMaritalStatus
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required]
        public int EmployeeId { get; set; } // Foreign Key to Employee

        [Required]
        public int MaritalStatusTypeId { get; set; } // Foreign Key to MaritalStatusType

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; } // Çalışan ile ilişki

        [ForeignKey("MaritalStatusTypeId")]
        public MaritalStatusType MaritalStatusType { get; set; } // Medeni Durum Türü ile ilişki
    }
}
