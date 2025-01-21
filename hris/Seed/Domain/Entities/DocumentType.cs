using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace hris.Seed.Domain.Entities
{
    public class DocumentType
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required, MaxLength(100)]
        public string Name { get; set; } // Belge türü adı (Örn: "Nüfus Cüzdanı", "Sağlık Raporu")

        [MaxLength(500)]
        public string? Description { get; set; } // Belge hakkında açıklama
    }

}
