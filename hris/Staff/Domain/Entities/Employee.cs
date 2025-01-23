using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hris.Staff.Domain.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string FirstName { get; set; } // Çalışanın adı

        [Required, MaxLength(100)]
        public string LastName { get; set; } // Çalışanın soyadı

        [Required, MaxLength(200)]
        public string Tckn { get; set; } // T.C. Kimlik Numarası

        [Required]
        public DateTime DateOfBirth { get; set; } // Doğum tarihi

        public DateTime? LastPasswordChange { get; set; } // Şifre değişim tarihi


        [Required]
        public DateTime CreatedAt { get; set; } // Employee Oluşturulma Tarihi

        // Navigation Properties

        public ICollection<EmployeePassword> Passwords { get; set; } = new List<EmployeePassword>(); // Adresleri
        public ICollection<EmployeeEmail> Emails { get; set; } = new List<EmployeeEmail>(); // Emailleri
        public ICollection<EmployeeAddress> Addresses { get; set; } = new List<EmployeeAddress>(); // Adresleri
        public ICollection<EmployeePhoneNumber> PhoneNumbers { get; set; } = new List<EmployeePhoneNumber>(); // Telefonları
        public ICollection<EmployeeBank> Banks { get; set; } = new List<EmployeeBank>(); // Banka Hesapları
        public ICollection<EmployeeEducation> Educations { get; set; } = new List<EmployeeEducation>(); // Eğitim Bilgileri
        public ICollection<EmployeeRelative> Relatives { get; set; } = new List<EmployeeRelative>(); // Yakınları
        public ICollection<EmployeePosition> Positions { get; set; } = new List<EmployeePosition>(); // Pozisyonları
        public ICollection<EmployeeDocument> Documents { get; set; } = new List<EmployeeDocument>(); // Belgeleri

    }
}
