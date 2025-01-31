using hris.Seed.Application.Dto._Position;

namespace hris.Seed.Application.Dto._Department
{
    public class DepartmentDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PositionSummaryDto> Positions { get; set; } = new();
    }

   
}
