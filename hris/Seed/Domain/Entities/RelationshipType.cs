using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using hris.Staff.Domain.Entities;


namespace hris.Seed.Domain.Entities
{
    public class RelationshipType
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required, MaxLength(50)]
        public string Name { get; set; } // Yakınlık Derecesi (örn: "Anne", "Baba", "Arkadaş")

        // Navigation Property
        public ICollection<EmployeeRelative> EmployeeRelatives { get; set; } = new List<EmployeeRelative>();
    }
}
