using hris.Database;
using hris.Seed.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hris.Seed.Application.Command._Position.Handler
{
	public class CreatePositionCommandHandler : IRequestHandler<CreatePositionCommand, int>
	{
		private readonly AppDbContext _context;

		public CreatePositionCommandHandler(AppDbContext context)
		{
			_context = context;
		}

		public async Task<int> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
		{
			// Departmanın var olup olmadığını kontrol et
			var department = await _context.Departments
				.FirstOrDefaultAsync(d => d.Id == request.DepartmentId, cancellationToken);

			if (department == null)
				throw new KeyNotFoundException("Department not found.");

			// Yeni pozisyon oluştur
			var newPosition = new Position
			{
				Name = request.Name,
				DepartmentId = request.DepartmentId
			};

			_context.Positions.Add(newPosition);
			await _context.SaveChangesAsync(cancellationToken);

			return newPosition.Id;
		}
	}
}
