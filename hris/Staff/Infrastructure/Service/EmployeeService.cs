using hris.Staff.Domain.Entities;
using hris.Staff.Application.Interface;
using hris.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace hris.Staff.Infrastructure.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees
                .Include(e => e.Addresses)
                .Include(e => e.PhoneNumbers)
                .Include(e => e.Emails)
                .Include(e => e.Banks)
                .Include(e => e.Educations)
                .Include(e => e.Relatives)
                .Include(e => e.Positions)
                .Include(e => e.Documents)
                .ToListAsync();
        }


        public async Task<Employee?> GetByIdAsync(int employeeId)
        {
            return await _context.Employees
                .Include(e => e.Addresses)
                .Include(e => e.PhoneNumbers)
                .Include(e => e.Emails)
                .Include(e => e.Banks)
                .Include(e => e.Educations)
                .Include(e => e.Relatives)
                .Include(e => e.Positions)
                .Include(e => e.Documents)
                .FirstOrDefaultAsync(e => e.Id == employeeId);
        }

        public async Task<Employee?> GetByTcknAsync(string Tckn)
        {
            return await _context.Employees
                .Include(e => e.Addresses)
                .Include(e => e.PhoneNumbers)
                .Include(e => e.Emails)
                .Include(e => e.Banks)
                .Include(e => e.Educations)
                .Include(e => e.Relatives)
                .Include(e => e.Positions)
                .Include(e => e.Documents)
                .FirstOrDefaultAsync(e => e.Tckn == Tckn);
        }

        public async Task<Employee> CreateAsync()
        {

            var newEmployee = new Employee
            {
                FirstName = "John",
                LastName = "Doe",
                Tckn = "12345678901",
                DateOfBirth = new DateTime(1990, 1, 1),
            };

            await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();

            return newEmployee;
        }



    }

}
