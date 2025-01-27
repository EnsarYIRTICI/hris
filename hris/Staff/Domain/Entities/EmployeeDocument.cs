using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using hris.Seed.Domain.Entities;

namespace hris.Staff.Domain.Entities
{
    public class EmployeeDocument
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public int DocumentTypeId { get; set; }

        [MaxLength(500)]
        public string FilePath { get; set; } 

        public DateTime UploadedAt { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        [ForeignKey("DocumentTypeId")]
        public DocumentType DocumentType { get; set; }
    }
}
