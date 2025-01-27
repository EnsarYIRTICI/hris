using hris.Staff.Domain.Entities;
using hris.Seed.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using hris.Division.Domain.Entities;

namespace hris.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeEmail> EmployeeEmails { get; set; }
        public DbSet<EmployeePassword> EmployeePasswords { get; set; }
        public DbSet<EmployeePhoneNumber> EmployeePhoneNumbers { get; set; }
        public DbSet<EmployeeAddress> EmployeeAddresses { get; set; }
        public DbSet<EmployeeBank> EmployeeBanks { get; set; }
        public DbSet<EmployeeEducation> EmployeeEducations { get; set; }
        public DbSet<EmployeeDocument> EmployeeDocuments { get; set; }
        public DbSet<EmployeeMilitaryStatus> EmployeeMilitaryStatuses { get; set; }
        public DbSet<EmployeeMaritalStatus> EmployeeMaritalStatuses { get; set; }
        public DbSet<EmployeeRelative> EmployeeRelatives { get; set; }
        public DbSet<EmployeePosition> EmployeePositions { get; set; }


        public DbSet<Position> Positions { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<PhoneNumberType> PhoneNumberTypes { get; set; }
        public DbSet<EmailType> EmailTypes { get; set; }
        public DbSet<MaritalStatusType> MaritalStatusTypes { get; set; }
        public DbSet<MilitaryStatusType> MilitaryStatusTypes { get; set; }
        public DbSet<RelationshipType> RelationshipTypes { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Unique Constraint

            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.Tckn)
                .IsUnique();

            modelBuilder.Entity<EmployeeEmail>()
                .HasIndex(e => e.Email)
                .IsUnique();

            modelBuilder.Entity<EmployeeEmail>()
                .HasIndex(p => new { p.EmployeeId, p.IsValid })
                .IsUnique()
                .HasFilter("[IsValid] = 1");

            modelBuilder.Entity<EmployeePassword>()
                .HasIndex(p => new { p.EmployeeId, p.IsValid })
                .IsUnique()
                .HasFilter("[IsValid] = 1");

            // Seed

            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "IT" }
            );

            modelBuilder.Entity<Position>().HasData(
                new Position { Id = 1, Name = "Manager", DepartmentId = 1 },
                new Position { Id = 2, Name = "Software Developer", DepartmentId = 1 }
            );

            modelBuilder.Entity<EmailType>().HasData(
                new EmailType { Id = 1, Name = "Personal" },
                new EmailType { Id = 2, Name = "Work" }
            );

            modelBuilder.Entity<PhoneNumberType>().HasData(
                new PhoneNumberType { Id = 1, Name = "Mobile" },
                new PhoneNumberType { Id = 2, Name = "Work" },
                new PhoneNumberType { Id = 3, Name = "Home" }
            );

            modelBuilder.Entity<RelationshipType>().HasData(
                new RelationshipType { Id = 1, Name = "Mother" }, // Anne
                new RelationshipType { Id = 2, Name = "Father" }, // Baba
                new RelationshipType { Id = 3, Name = "Spouse" }, // Eş
                new RelationshipType { Id = 4, Name = "Sibling" }, // Kardeş
                new RelationshipType { Id = 5, Name = "Friend" } // Arkadaş
            );

            modelBuilder.Entity<MaritalStatusType>().HasData(
                new MaritalStatusType { Id = 1, Name = "Married" }, // Evli
                new MaritalStatusType { Id = 2, Name = "Single" }, // Bekar
                new MaritalStatusType { Id = 3, Name = "Widowed" } // Dul
            );

            modelBuilder.Entity<MilitaryStatusType>().HasData(
                new MilitaryStatusType { Id = 1, Name = "Completed" }, // Tamamlandı
                new MilitaryStatusType { Id = 2, Name = "Deferred" }, // Tecilli
                new MilitaryStatusType { Id = 3, Name = "Exempt" } // Muaf
            );

            modelBuilder.Entity<Bank>().HasData(
                new Bank { Id = 1, Name = "Ziraat Bank", SwiftCode = "TCZBTR2A" },
                new Bank { Id = 2, Name = "Garanti BBVA", SwiftCode = "TGBATRIS" },
                new Bank { Id = 3, Name = "Akbank", SwiftCode = "AKBKTRIS" },
                new Bank { Id = 4, Name = "Yapı Kredi Bank", SwiftCode = "YAPITRISFEX" }
            );

            modelBuilder.Entity<Country>().HasData(
               new Country { Id = 1, Name = "Turkey", PhoneCode = "+90", ShortCode = "TR" }, // Türkiye
               new Country { Id = 2, Name = "USA", PhoneCode = "+1", ShortCode = "US" }, // ABD
               new Country { Id = 3, Name = "Germany", PhoneCode = "+49", ShortCode = "DE" } // Almanya
            );

            modelBuilder.Entity<DocumentType>().HasData(
                new DocumentType { Id = 1, Name = "ID Copy" }, // Kimlik Fotokopisi
                new DocumentType { Id = 2, Name = "Health Report" }, // Sağlık Raporu
                new DocumentType { Id = 3, Name = "Criminal Record" }, // Adli Sicil Kaydı
                new DocumentType { Id = 4, Name = "Proof of Residence" }, // İkametgâh Belgesi
                new DocumentType { Id = 5, Name = "Education Certificate" } // Eğitim Sertifikası
            );



        }

    }
}
