using AutoMapper;
using hris.Staff.Application.Command;
using hris.Staff.Application.Dto;
using hris.Staff.Application.Query;
using hris.Staff.Domain.Entities;
using MediatR;

namespace hris.Seed.Application.Service
{
    public class SeedService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public SeedService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<Employee> SeedAdminEmployeeAsync()
        {
            var existingEmployee = await _mediator.Send(new GetEmployeeByTcknQuery("12345678901"));

            if (existingEmployee == null)
            {
                var createEmployeeDto = new CreateEmployeeDto()
                {
                    FirstName = "Ahmet",
                    LastName = "Yılmaz",
                    Tckn = "12345678901",
                    Emails = new List<EmailDto>
                    {
                        new EmailDto
                        {
                            Email = "turing@turing.com",
                            EmailTypeId = 2
                        },
                    },
                    PhoneNumbers = new List<PhoneDto>
                    {
                        new PhoneDto
                        {
                            PhoneNumber = "5355252071",
                            PhoneTypeId = 2,
                            CountryId = 1,
                        }
                    },
                    Password = "turing",
                    PositionId = 1,
                };

                var createEmployeeCommand = _mapper.Map<CreateEmployeeCommand>(createEmployeeDto);
                var employee = await _mediator.Send(createEmployeeCommand);
                return employee;
            }

            return existingEmployee;
        }
    }
}
