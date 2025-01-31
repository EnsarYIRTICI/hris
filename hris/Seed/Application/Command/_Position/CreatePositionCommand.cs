using MediatR;

namespace hris.Seed.Application.Command._Position
{
	public class CreatePositionCommand : IRequest<int>
	{
		public int DepartmentId { get; set; }
		public string Name { get; set; }
	}

}
