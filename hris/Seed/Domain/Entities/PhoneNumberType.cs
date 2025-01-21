using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using hris.Staff.Domain.Entities;


namespace hris.Seed.Domain.Entities
{
    public class PhoneNumberType
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required, MaxLength(50)]
        public string Name { get; set; } // Tür Adı (örn: "Mobile", "Work")

        public ICollection<EmployeePhoneNumber> PhoneNumbers { get; set; } = new List<EmployeePhoneNumber>();
    }
}
