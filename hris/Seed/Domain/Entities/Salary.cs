using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using hris.Staff.Domain.Entities;


namespace hris.Seed.Domain.Entities
{
    public class Salary
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required]
        public decimal Amount { get; set; } // Maaş miktarı

        [Required]
        public DateTime EffectiveDate { get; set; } // Maaşın yürürlüğe girdiği tarih

        public DateTime? EndDate { get; set; } // Maaşın sona erdiği tarih (opsiyonel)

        [Required]
        public int PositionId { get; set; } // Foreign Key to EmployeePositionSet

        [ForeignKey("PositionId")]
        public EmployeePosition Position { get; set; } // EmployeePositionSet ile ilişki
    }
}
