using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using hris.Staff.Domain.Entities;


namespace hris.Seed.Domain.Entities
{
    public class Position
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required, MaxLength(100)]
        public string Name { get; set; } // Pozisyon adı (örn: "Software Engineer")

        [Required]
        public int DepartmentId { get; set; } // Foreign Key to DepartmentTemplate

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; } // Departman ile ilişki

        public ICollection<EmployeePosition> EmployeePositions { get; set; } = new List<EmployeePosition>(); // Çalışan Pozisyonları
    }
}
