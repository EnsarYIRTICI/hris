﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hris.Seed.Domain.Entities
{
    public class Department
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required, MaxLength(100)]
        public string Name { get; set; } // Departman Adı (örn: "IT", "HR")

        public ICollection<Position> Positions { get; set; } = new List<Position>(); // Departmandaki pozisyon şablonları
    }
}
