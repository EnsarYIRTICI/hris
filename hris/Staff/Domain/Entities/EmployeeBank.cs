using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using hris.Seed.Domain.Entities;

namespace hris.Staff.Domain.Entities
{
    public class EmployeeBank
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required]
        public int EmployeeId { get; set; } // Foreign Key to Employee

        [Required]
        public int BankId { get; set; } // Foreign Key to Bank

        [MaxLength(50)]
        public string AccountNumber { get; set; } // Hesap Numarası

        [MaxLength(50)]
        public string IBAN { get; set; } // IBAN

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; } // Çalışan ile ilişki

        [ForeignKey("BankId")]
        public Bank Bank { get; set; } // Banka ile ilişki
    }
}
