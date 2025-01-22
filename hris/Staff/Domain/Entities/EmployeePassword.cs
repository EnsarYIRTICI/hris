using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hris.Staff.Domain.Entities
{
    public class EmployeePassword
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required]
        public int EmployeeId { get; set; } // Foreign Key to Employee

        [Required]
        public byte[] PasswordHash { get; set; } // Şifrelenmiş Parola

        [Required]
        public byte[] PasswordSalt { get; set; } // Şifreleme İçin Kullanılan Salt

        [Required]
        public bool IsValid { get; set; } = true; // Şifrenin Aktiflik Durumu

        [Required]
        public DateTime CreatedAt { get; set; } // Şifre Oluşturulma Tarihi

        public DateTime? ExpiryDate { get; set; } // Şifrenin Geçerlilik Süresi (Opsiyonel)


        // Navigation Property
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
    }
}
