using AutoMapper;
using hris.Database;
using hris.Seed.Domain.Entities;
using hris.Staff.Application.Command;
using hris.Staff.Application.Dto;
using hris.Staff.Application.Service;
using hris.Staff.Domain.Entities;
using MediatR;
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

        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

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

                var createEmployeeDto = new CreateEmployeeDto()
                {

                    FirstName = "Ahmet",
                    LastName = "Yılmaz",
                    Tckn = "12345678901",
                    Emails = new List<EmailDto>()
                    {
                        new EmailDto
                        {
                            Email = "turing@turing.com",
                            EmailTypeId = 2
                        }
                    },
                    Password = "turing",
                    PositionId = 1,

                };

                var command = _mapper.Map<CreateEmployeeCommand>(createEmployeeDto);
                var employee = await _mediator.Send(command);

                return employee;

            }

            return existingEmployee;
        }

    }


}
