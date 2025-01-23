using AutoMapper;
using hris.Database;
using hris.Seed.Application.Service;
using hris.Seed.Domain.Entities;
using hris.Staff.Application.Service;
using hris.Staff.Domain.Entities;
using MediatR;

namespace hris.Staff.Application.Command
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Employee>
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly EmployeePasswordService _employeePasswordService;
        private readonly PhoneNumberTypeService _phoneNumberTypeService;
        private readonly EmailTypeService _emailTypeService;
        private readonly PositionService _positionService;
        public CreateEmployeeCommandHandler(
            IMapper mapper,
            AppDbContext context,
            EmployeePasswordService employeePasswordService,
            PhoneNumberTypeService phoneNumberTypeService,
            EmailTypeService emailTypeService,
            PositionService positionService)
        {
            _mapper = mapper;
            _context = context;
            _employeePasswordService = employeePasswordService;
            _phoneNumberTypeService = phoneNumberTypeService;
            _emailTypeService = emailTypeService;
            _positionService = positionService;
        }

        public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var createdAt = DateTime.UtcNow;

            _employeePasswordService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            PhoneNumberType mobilePhone = await _phoneNumberTypeService.GetMobileAsync();
            EmailType personalEmail = await _emailTypeService.GetPersonalAsync();
            Position position = await _positionService.GetByIdThrowAsync(request.PositionId);

            var newEmployee = new Employee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Tckn = request.Tckn,
                DateOfBirth = request.DateOfBirth,
                CreatedAt = createdAt,
            };

            newEmployee.PhoneNumbers.Add(new EmployeePhoneNumber
            {
                PhoneNumber = request.PhoneNumber,
                PhoneNumberType = mobilePhone,
                CreatedAt = createdAt
            });

            newEmployee.Emails.Add(new EmployeeEmail
            {
                Email = request.Email,
                IsApproved = true,
                IsValid = true,
                CreatedAt = createdAt,
                EmailType = personalEmail
            });

            newEmployee.Passwords.Add(new EmployeePassword
            {
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedAt = createdAt
            });

            newEmployee.Positions.Add(new EmployeePosition
            {
                Position = position,
                StartDate = createdAt
            });

            await _context.Employees.AddAsync(newEmployee, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return newEmployee;
        }
    }
}
