using hris.Staff.Application.Dto._Employee;

namespace hris.Seed.Application.Dto._Position
{
    public class PositionDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public List<EmployeeSummary> Employees { get; set; } = new();
    }

}
