using AutoMapper;
using hris.Staff.Application.Command;
using hris.Staff.Application.Dto;

namespace hris.Staff.Application.Mapping
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<CreateEmployeeDto, CreateEmployeeCommand>();

            CreateMap<PhoneDto, PhoneNumberCommand>();
            CreateMap<EmailDto, EmailCommand>();
        }
    }
}