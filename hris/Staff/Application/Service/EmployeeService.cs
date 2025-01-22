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
        private readonly PositionService _positionService;

        public EmployeeService(
            AppDbContext context,
            EmployeeEmailService employeeEmailService,
            EmployeePasswordService employeePasswordService,
            EmailTypeService emailTypeService,
            PositionService positionService
            )
        {
            _context = context;
            _employeeEmailService = employeeEmailService;
            _employeePasswordService = employeePasswordService;
            _emailTypeService = emailTypeService;
            _positionService = positionService;
        }


        public async Task<List<Employee>> SearchByFullNameAsync(string fullName)
        {
            return await _context.Employees
                .Where(e => EF.Functions.Like(e.FirstName + " " + e.LastName, $"%{fullName}%"))
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

            EmailType personalEmail = await _emailTypeService.GetPersonalAsync();
            Position developerPosition = await _positionService.GetSoftwareDeveloperPositionAsync();


            var newEmployee = new Employee
            {
                FirstName = createEmployeeDto.FirstName,
                LastName = createEmployeeDto.LastName,
                Tckn = createEmployeeDto.Tckn,
                DateOfBirth = createEmployeeDto.DateOfBirth,
                CreatedAt = createdAt,
            };


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
                Position = developerPosition,
                StartDate = createdAt
            });

            await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();

            return newEmployee;
        }



    }

}
