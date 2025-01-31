using hris.Database;
using hris.Staff.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hris.Staff.Application.Command._EmployeePosition.Handler
{
    public class AddEmployeeToPositionCommandHandler : IRequestHandler<AddEmployeeToPositionCommand, bool>
    {
        private readonly AppDbContext _context;

        public AddEmployeeToPositionCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(AddEmployeeToPositionCommand request, CancellationToken cancellationToken)
        {
            // Pozisyonu ve çalışanı kontrol et
            var position = await _context.Positions
                .FirstOrDefaultAsync(p => p.Id == request.PositionId, cancellationToken);

            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.Id == request.EmployeeId, cancellationToken);

            if (position == null)
                throw new KeyNotFoundException("Position not found.");

            if (employee == null)
                throw new KeyNotFoundException("Employee not found.");

            // Çalışan zaten bu pozisyonda mı?
            bool alreadyAssigned = await _context.EmployeePositions
                .AnyAsync(ep => ep.PositionId == request.PositionId && ep.EmployeeId == request.EmployeeId, cancellationToken);

            if (alreadyAssigned)
                throw new InvalidOperationException("Employee is already assigned to this position.");

            // Yeni EmployeePosition kaydı oluştur
            var employeePosition = new EmployeePosition
            {
                PositionId = request.PositionId,
                EmployeeId = request.EmployeeId,
                StartDate = DateTime.UtcNow
            };

            _context.EmployeePositions.Add(employeePosition);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
