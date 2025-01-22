using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using hris.Seed.Domain.Entities;

namespace hris.Staff.Domain.Entities
{
    public class EmployeeEmail
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required]
        public int EmployeeId { get; set; } // Foreign Key to Employee

        [Required, MaxLength(200)]
        [EmailAddress]
        public string Email { get; set; } // E-posta adresi

        [Required]
        public bool IsValid { get; set; } = true; // Şifrenin Aktiflik Durumu

        [Required]
        public bool IsApproved { get; set; } = true; // Şifrenin Aktiflik Durumu

        [Required]
        public bool IsDeleted { get; set; } = false; // Şifrenin Aktiflik Durumu

        [Required]
        public DateTime CreatedAt { get; set; } // Email Oluşturulma Tarihi

        [Required]
        public int EmailTypeId { get; set; } // Foreign Key to EmailType

        [ForeignKey("EmailTypeId")]
        public EmailType EmailType { get; set; } // E-posta Türü

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; } // Çalışan ile ilişki
    }
}
