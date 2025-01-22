using hris.Database;
using hris.Seed.Domain.Entities;
using hris.Staff.Application.Dto;
using hris.Staff.Application.Service;
using hris.Staff.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hris.Seed.Application.Service
{
    public class SeedService
    {
        private readonly AppDbContext _context;
        private readonly EmployeeService _employeeService;
        private readonly EmailTypeService _emailTypeService;
        private readonly EmployeePasswordService _employeePasswordService;
        private readonly PositionService _positionService;

        public SeedService(
            AppDbContext context,
            EmailTypeService emailTypeService,
            EmployeePasswordService employeePasswordService,
            PositionService positionService,
            EmployeeService employeeService
            )
        {
            _context = context;
            _emailTypeService = emailTypeService;
            _employeePasswordService = employeePasswordService;
            _positionService = positionService;
            _employeeService = employeeService;
        }

        public async Task<Employee> SeedAdminEmployeeAsync()
        {

            // Çalışanı kontrol et

            Employee? existingEmployee = await _employeeService.GetByTcknAsync("12345678901");

            if (existingEmployee == null)
            {

                // Yeni çalışan oluştur

                var newEmployee = await _employeeService.CreateAsync(new CreateEmployeeDto()
                {

                    FirstName = "Ahmet",
                    LastName = "Yılmaz",
                    Tckn = "12345678901",
                    DateOfBirth = new DateTime(1985, 5, 15),
                    Email = "turing@turing.com",
                    Password = "turing",
                    EmailTypeId = 2,
                    PositionId = 1,

                });

                return newEmployee;

            }

            return existingEmployee;
        }

    }


}
