using hris.Seed.Application.Dto._Department;
using MediatR;

namespace hris.Seed.Application.Query._Department
{
    public class GetDepartmentDetailsQuery : IRequest<DepartmentDetailsDto>
    {
        public int DepartmentId { get; set; }

        public GetDepartmentDetailsQuery(int departmentId)
        {
            DepartmentId = departmentId;
        }
    }

}
