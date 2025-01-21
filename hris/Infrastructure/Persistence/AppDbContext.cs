using hris.Staff.Domain.Entities;
using hris.Seed.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace hris.Infrastructure.Persistence
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

            // Statik Veriler

            modelBuilder.Entity<RelationshipType>().HasData(
                new RelationshipType { Id = 1, Name = "Anne" },
                new RelationshipType { Id = 2, Name = "Baba" },
                new RelationshipType { Id = 3, Name = "Eş" },
                new RelationshipType { Id = 4, Name = "Kardeş" },
                new RelationshipType { Id = 5, Name = "Arkadaş" }
            );

            modelBuilder.Entity<MaritalStatusType>().HasData(
                new MaritalStatusType { Id = 1, Name = "Evli" },
                new MaritalStatusType { Id = 2, Name = "Bekar" },
                new MaritalStatusType { Id = 3, Name = "Dul" }
            );

            modelBuilder.Entity<MilitaryStatusType>().HasData(
                new MilitaryStatusType { Id = 1, Name = "Tamamlandı" },
                new MilitaryStatusType { Id = 2, Name = "Tecilli" },
                new MilitaryStatusType { Id = 3, Name = "Muaf" }
            );

            modelBuilder.Entity<Bank>().HasData(
                new Bank { Id = 1, Name = "Ziraat Bankası", SwiftCode = "TCZBTR2A" },
                new Bank { Id = 2, Name = "Garanti BBVA", SwiftCode = "TGBATRIS" },
                new Bank { Id = 3, Name = "Akbank", SwiftCode = "AKBKTRIS" },
                new Bank { Id = 4, Name = "Yapı Kredi Bankası", SwiftCode = "YAPITRISFEX" }
            );

            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Türkiye" },
                new Country { Id = 2, Name = "ABD" },
                new Country { Id = 3, Name = "Almanya" }
            );

            modelBuilder.Entity<PhoneNumberType>().HasData(
                new PhoneNumberType { Id = 1, Name = "Mobile" },
                new PhoneNumberType { Id = 2, Name = "Work" },
                new PhoneNumberType { Id = 3, Name = "Home" }
            );

            modelBuilder.Entity<DocumentType>().HasData(
            new DocumentType { Id = 1, Name = "Kimlik Fotokopisi" },
            new DocumentType { Id = 2, Name = "Sağlık Raporu" },
            new DocumentType { Id = 3, Name = "Adli Sicil Kaydı" },
            new DocumentType { Id = 4, Name = "İkametgâh Belgesi" },
            new DocumentType { Id = 5, Name = "Eğitim Sertifikası" }
            );

            modelBuilder.Entity<EmailType>().HasData(
                new EmailType { Id = 1, Name = "Personal" },
                new EmailType { Id = 2, Name = "Work" }
            );


            // Unique Constraint

            modelBuilder.Entity<EmployeePassword>()
                .HasIndex(p => new { p.EmployeeId, p.IsValid })
                .IsUnique()
                .HasFilter("[IsValid] = 1");

            modelBuilder.Entity<EmployeeEmail>()
                .HasIndex(p => new { p.EmployeeId, p.IsValid })
                .IsUnique()
                .HasFilter("[IsValid] = 1");
        }

    }
}
