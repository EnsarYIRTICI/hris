using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using hris.Seed.Domain.Entities;

namespace hris.Staff.Domain.Entities
{
    public class EmployeePosition
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required]
        public int EmployeeId { get; set; } // Foreign Key to Employee

        [Required]
        public int PositionId { get; set; } // Foreign Key to Position

        [Required]
        public DateTime StartDate { get; set; } // Pozisyon başlangıç tarihi

        public DateTime? EndDate { get; set; } // Pozisyon bitiş tarihi (opsiyonel)

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; } // Çalışan ile ilişki

        [ForeignKey("PositionId")]
        public Position Position { get; set; } // Statik Pozisyon ile ilişki

        // Navigation Property
        public ICollection<Salary> Salaries { get; set; } = new List<Salary>(); // Maaşlar ile ilişki
    }
}
