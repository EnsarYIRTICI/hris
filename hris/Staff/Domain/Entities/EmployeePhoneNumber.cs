using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using hris.Seed.Domain.Entities;

namespace hris.Staff.Domain.Entities
{
    public class EmployeePhoneNumber
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required]
        public int EmployeeId { get; set; } // Foreign Key to Employee

        [Required, MaxLength(15)]
        public string Number { get; set; } // Telefon numarası

        [Required]
        public int PhoneNumberTypeId { get; set; } // Foreign Key to PhoneNumberType

        [ForeignKey("PhoneNumberTypeId")]
        public PhoneNumberType PhoneNumberType { get; set; } // Telefon Numarası Türü

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; } // Çalışan ile ilişki
    }
}
