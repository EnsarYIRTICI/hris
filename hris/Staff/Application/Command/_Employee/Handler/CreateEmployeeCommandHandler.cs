using hris.Database;
using hris.Seed.Application.Query;
using hris.Seed.Application.Query._Country;
using hris.Seed.Application.Query._EmailType;
using hris.Seed.Application.Query._PhoneNumberType;
using hris.Seed.Application.Query._Position;
using hris.Seed.Domain.Entities;
using hris.Staff.Application.Command._Employee;
using hris.Staff.Application.Command._EmployeePassword;
using hris.Staff.Application.Dto;
using hris.Staff.Domain.Entities;
using MediatR;

namespace hris.Staff.Application.Command._Employee.Handler
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Employee>
    {
        private readonly AppDbContext _context;
        private readonly IMediator _mediator;

        public CreateEmployeeCommandHandler(
            AppDbContext context,
            IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var createdAt = DateTime.UtcNow;

            var newEmployee = new Employee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Tckn = request.Tckn,
                DateOfBirth = request.DateOfBirth,
                CreatedAt = createdAt,
            };

            // Telefon numaraları ekleniyor
            foreach (var phoneNumber in request.PhoneNumbers)
            {
                var phoneNumberType = await _mediator.Send(new GetPhoneNumberTypeByIdQuery(phoneNumber.PhoneTypeId), cancellationToken);
                var country = await _mediator.Send(new GetCountryByIdQuery(phoneNumber.CountryId), cancellationToken);

                newEmployee.PhoneNumbers.Add(new EmployeePhoneNumber
                {
                    PhoneNumber = phoneNumber.PhoneNumber,
                    Country = country,
                    PhoneNumberType = phoneNumberType,
                    CreatedAt = createdAt,
                });
            }

            // E-postalar ekleniyor
            for (int i = 0; i < request.Emails.Count; i++)
            {
                var email = request.Emails[i];
                var emailType = await _mediator.Send(new GetEmailTypeByIdQuery(email.EmailTypeId), cancellationToken);

                newEmployee.Emails.Add(new EmployeeEmail
                {
                    Email = email.Email,
                    EmailType = emailType,
                    IsValid = i == 0, // İlk e-posta varsayılan olarak geçerli kabul edilir
                    IsApproved = true,
                    CreatedAt = createdAt,
                });
            }

            // Şifre oluşturuluyor
            var (passwordHash, passwordSalt) = await _mediator.Send(new CreatePasswordHashCommand(request.Password));

            newEmployee.Passwords.Add(new EmployeePassword
            {
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedAt = createdAt,
            });

            // Pozisyon ekleniyor
            var position = await _mediator.Send(new GetPositionByIdQuery(request.PositionId), cancellationToken);

            newEmployee.Positions.Add(new EmployeePosition
            {
                Position = position,
                StartDate = createdAt,
            });

            // Veritabanına kaydediliyor
            await _context.Employees.AddAsync(newEmployee, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return newEmployee;
        }
    }
}
