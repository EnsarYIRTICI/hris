using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using hris.Seed.Domain.Entities;

namespace hris.Staff.Domain.Entities
{
    public class EmployeePhoneNumber
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        public int EmployeeId { get; set; } 

        [Required, MaxLength(15)]
        public string PhoneNumber { get; set; } 

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public int PhoneNumberTypeId { get; set; }

        [ForeignKey("PhoneNumberTypeId")]
        public PhoneNumberType PhoneNumberType { get; set; }

        [Required]
        public int CountryId { get; set; } 

        [ForeignKey("CountryId")]
        public Country Country { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; } 
    }
}
