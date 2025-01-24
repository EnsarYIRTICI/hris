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

        public async Task<Employee> GetByIdWithDetailsAsync(int employeeId)
        {
            Employee? employee = await _context.Employees
             .Include(e => e.Passwords)
             .Include(e => e.Emails)
             .Include(e => e.Addresses)
             .Include(e => e.PhoneNumbers)
             .Include(e => e.Banks)
             .Include(e => e.Educations)
             .Include(e => e.Relatives)
             .Include(e => e.Positions)
             .Include(e => e.Documents)
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
