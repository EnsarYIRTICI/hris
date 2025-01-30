using System.ComponentModel.DataAnnotations;

namespace hris.Seed.Application.Dto._Department
{
    public class CreateDepartmentDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public List<PositionDto> Positions { get; set; } = new List<PositionDto> { new PositionDto() };

        public bool AddPosition { get; set; } = false;
        public int DeletePositionId { get; set; }

    }

    public class PositionDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
    }
}
