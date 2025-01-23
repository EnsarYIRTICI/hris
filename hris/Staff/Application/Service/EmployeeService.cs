using hris.Staff.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;
using hris.Seed.Domain.Entities;
using hris.Staff.Domain.Exceptions;
using hris.Seed.Application.Service;
using hris.Staff.Application.Dto;
using hris.Database;
using System.Collections.Generic;

namespace hris.Staff.Application.Service
{
    public class EmployeeService
    {
        private readonly AppDbContext _context;
        private readonly EmployeeEmailService _employeeEmailService;
        private readonly EmployeePasswordService _employeePasswordService;
        private readonly EmailTypeService _emailTypeService;
        private readonly PhoneNumberTypeService _phoneNumberTypeService;
        private readonly PositionService _positionService;

        public EmployeeService(
            AppDbContext context,
            EmployeeEmailService employeeEmailService,
            EmployeePasswordService employeePasswordService,
            EmailTypeService emailTypeService,
            PositionService positionService,
            PhoneNumberTypeService phoneNumberTypeService
            )
        {
            _context = context;
            _employeeEmailService = employeeEmailService;
            _employeePasswordService = employeePasswordService;
            _emailTypeService = emailTypeService;
            _positionService = positionService;
            _phoneNumberTypeService = phoneNumberTypeService;
        }

        public async Task<int> GetTotalEmployeesAsync()
        {
            return await _context.Employees.CountAsync();
        }


        public async Task<List<Employee>> SearchByFullNameOrTcknAsync(string searchQuery)
        {
            return await _context.Employees
            .Where(e =>
                    EF.Functions.Like(e.FirstName + " " + e.LastName, $"%{searchQuery}%") ||
                    EF.Functions.Like(e.Tckn, $"{searchQuery}%"))
                .OrderBy(e => e.Id)
                .Skip(0)
                .Take(50)
                .ToListAsync();
        }

        public async Task<List<Employee>> GetAllAsync(int offset)
        {
            return await _context.Employees
                .OrderBy(e => e.Id)
                .Skip(offset)
                .Take(50)
                .ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int employeeId)
        {
            Employee? employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.Id == employeeId);

            if (employee == null)
            {
                throw new EmployeeNotFoundException();
            }

            return employee;
        }


        public async Task<Employee?> GetByTcknAsync(string Tckn)
        {
            return await _context.Employees
                .FirstOrDefaultAsync(e => e.Tckn == Tckn);
        }

        public async Task<EmployeeSummary?> GetSummaryByIdAsync(int employeeId)
        {
            Employee employee = await GetByIdAsync(employeeId);

            EmployeeEmail validatedEmail = await _employeeEmailService.GetValidEmailsAsync(employee);

            return new EmployeeSummary()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                LastPasswordChange = employee.LastPasswordChange,
                Email = validatedEmail.Email
            };
        }

        public async Task<Employee> CreateAsync(CreateEmployeeDto createEmployeeDto)
        {
            var createdAt = DateTime.UtcNow;

            _employeePasswordService.CreatePasswordHash(createEmployeeDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            PhoneNumberType mobilePhone = await _phoneNumberTypeService.GetMobileAsync();
            EmailType personalEmail = await _emailTypeService.GetPersonalAsync();
            Position position = await _positionService.GetByIdThrowAsync(createEmployeeDto.PositionId);


            var newEmployee = new Employee
            {
                FirstName = createEmployeeDto.FirstName,
                LastName = createEmployeeDto.LastName,
                Tckn = createEmployeeDto.Tckn,
                DateOfBirth = createEmployeeDto.DateOfBirth,
                CreatedAt = createdAt,
            };


            newEmployee.PhoneNumbers.Add(new EmployeePhoneNumber()
            {
                PhoneNumber = createEmployeeDto.PhoneNumber,
                PhoneNumberType = mobilePhone,
                CreatedAt = createdAt
            });


            newEmployee.Emails.Add(new EmployeeEmail()
            {
                Email = createEmployeeDto.Email,
                IsApproved = true,
                IsValid = true,
                CreatedAt = createdAt,
                EmailType = personalEmail,
            });

            newEmployee.Passwords.Add(new EmployeePassword()
            {
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedAt = createdAt,
            });

            newEmployee.Positions.Add(new EmployeePosition()
            {
                Position = position,
                StartDate = createdAt
            });

            await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();

            return newEmployee;
        }


        public async Task UpdateAsync(UpdateEmployeeDto updateEmployeeDto)
        {
            Employee employee = await GetByIdAsync(updateEmployeeDto.Id);

            employee.DateOfBirth = updateEmployeeDto.DateOfBirth;
            employee.FirstName = updateEmployeeDto.FirstName;
            employee.LastName = updateEmployeeDto.LastName;
            employee.Tckn = updateEmployeeDto.Tckn;

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int employeeId)
        {
            Employee employee = await GetByIdAsync(employeeId);

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }



    }

}
