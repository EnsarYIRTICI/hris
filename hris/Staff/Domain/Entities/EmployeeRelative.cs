using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using hris.Seed.Domain.Entities;

namespace hris.Staff.Domain.Entities
{
    public class EmployeeRelative
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required]
        public int EmployeeId { get; set; } // Foreign Key to Employee

        [Required]
        public int RelationshipTypeId { get; set; } // Foreign Key to RelationshipType

        [Required, MaxLength(100)]
        public string Name { get; set; } // Yakının Adı

        [MaxLength(15)]
        public string PhoneNumber { get; set; } // Telefon Numarası

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; } // Çalışan ile ilişki

        [ForeignKey("RelationshipTypeId")]
        public RelationshipType RelationshipType { get; set; } // Yakınlık Türü ile ilişki
    }
}
