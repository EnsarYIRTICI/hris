using AutoMapper;
using hris.Staff.Application.Command._Employee;
using hris.Staff.Application.Dto._Employee;

namespace hris.Staff.Mapping
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<CreateEmployeeDto, CreateEmployeeCommand>();
     
        }
    }
}