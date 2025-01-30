using AutoMapper;
using hris.Seed.Application.Command._Department;
using hris.Seed.Application.Dto._Department;
using hris.Staff.Application.Command._Employee;
using hris.Staff.Application.Dto._Employee;

namespace hris.Seed.Mapping
{
    public class SeedMappingProfile : Profile
    {
        public SeedMappingProfile()
        {
            CreateMap<CreateDepartmentDto, CreateDepartmentCommand>();
        }
    }
}
