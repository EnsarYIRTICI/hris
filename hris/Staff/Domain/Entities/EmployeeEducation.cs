using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hris.Staff.Domain.Entities
{
    public class EmployeeEducation
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required]
        public int EmployeeId { get; set; } // Foreign Key to Employee

        [MaxLength(100)]
        public string SchoolName { get; set; } // Okul Adı

        [MaxLength(100)]
        public string Degree { get; set; } // Diploma/Derece

        public DateTime? StartDate { get; set; } // Başlangıç Tarihi
        public DateTime? EndDate { get; set; } // Bitiş Tarihi

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; } // Çalışan ile ilişki
    }
}
