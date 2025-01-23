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
        private readonly EmployeeService _employeeService;

        public SeedService(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<Employee> SeedAdminEmployeeAsync()
        {

            // Admin Çalışanı kontrol et

            Employee? existingEmployee = await _employeeService.GetByTcknAsync("12345678901");

            if (existingEmployee == null)
            {

                // Yeni Admin çalışan oluştur

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
