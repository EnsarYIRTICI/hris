using AutoMapper;
using hris.Database;
using hris.Seed.Application.Service;
using hris.Seed.Domain.Entities;
using hris.Staff.Application.Dto;
using hris.Staff.Application.Service;
using hris.Staff.Domain.Entities;
using MediatR;

namespace hris.Staff.Application.Command
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeDto, Employee>
    {
        private readonly AppDbContext _context;
        private readonly EmployeePasswordService _employeePasswordService;

        private readonly CountryService _countryService;
        private readonly PhoneNumberTypeService _phoneNumberTypeService;
        private readonly EmailTypeService _emailTypeService;
        private readonly PositionService _positionService;
        public CreateEmployeeCommandHandler(
            AppDbContext context,
            EmployeePasswordService employeePasswordService,

            CountryService countryService,
            PhoneNumberTypeService phoneNumberTypeService,
            EmailTypeService emailTypeService,
            PositionService positionService)
        {
            _context = context;
            _employeePasswordService = employeePasswordService;

            _countryService = countryService;
            _phoneNumberTypeService = phoneNumberTypeService;
            _emailTypeService = emailTypeService;
            _positionService = positionService;
        }

        public async Task<Employee> Handle(CreateEmployeeDto request, CancellationToken cancellationToken)
        {
            // Tarih

            var createdAt = DateTime.UtcNow;


            // Yeni çalışan nesnesi oluşturma

            var newEmployee = new Employee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Tckn = request.Tckn,
                DateOfBirth = request.DateOfBirth,
                CreatedAt = createdAt,
            };

            // Telefonlar ekleniyor (Birden fazla telefon için döngü ekledik)

            for (int i = 0; i < request.PhoneNumbers.Count; i++)
            {
                var phoneNumber = request.PhoneNumbers[i];
                var phoneNumberType = await _phoneNumberTypeService.GetByIdOrThrowAsync(phoneNumber.PhoneTypeId);
                var country = await _countryService.GetByIdAsync(phoneNumber.CountryId);

                newEmployee.PhoneNumbers.Add(new EmployeePhoneNumber
                {
                    PhoneNumber = phoneNumber.PhoneNumber,
                    Country = country,
                    PhoneNumberType = phoneNumberType,
                    CreatedAt = createdAt,
                });
            }

            // E-postalar ekleniyor (Birden fazla e-posta için döngü ekledik)

            for (int i = 0; i < request.Emails.Count; i++)
            {
                var email = request.Emails[i];
                var emailType = await _emailTypeService.GetByIdAsync(email.EmailTypeId);

                newEmployee.Emails.Add(new EmployeeEmail
                {
                    Email = email.Email,
                    EmailType = emailType,
                    IsValid = i == 0, // İlk e-posta varsayılan olarak geçerli kabul edilir
                    IsApproved = true,
                    CreatedAt = createdAt,
                });
            }

            // Şifre ekleniyor

            _employeePasswordService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            newEmployee.Passwords.Add(new EmployeePassword
            {
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedAt = createdAt,
            });

            // Pozisyon ekleniyor

            var position = await _positionService.GetByIdAsync(request.PositionId);

            newEmployee.Positions.Add(new EmployeePosition
            {
                Position = position,
                StartDate = createdAt,
            });

            // Veritabanına kaydetme

            await _context.Employees.AddAsync(newEmployee, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return newEmployee;
        }
    }
}
