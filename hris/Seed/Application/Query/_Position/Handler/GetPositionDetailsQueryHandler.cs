using hris.Database;
using hris.Seed.Application.Dto._Department;
using hris.Seed.Application.Dto._Position;
using hris.Staff.Application.Dto._Employee;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hris.Seed.Application.Query._Position.Handler
{
    public class GetPositionDetailsQueryHandler : IRequestHandler<GetPositionDetailsQuery, PositionDetailsDto>
    {
        private readonly AppDbContext _context;

        public GetPositionDetailsQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PositionDetailsDto> Handle(GetPositionDetailsQuery request, CancellationToken cancellationToken)
        {
            var position = await _context.Positions
                .Where(p => p.Id == request.PositionId)
                .Include(p => p.Department) // Departman bilgisi
                .Include(p => p.EmployeePositions)
                    .ThenInclude(ep => ep.Employee) // Çalışan bilgileri
                .Select(p => new PositionDetailsDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    DepartmentId = p.Department.Id,
                    DepartmentName = p.Department.Name,
                    Employees = p.EmployeePositions.Select(ep => new EmployeeSummary
                    {
                        FirstName = ep.Employee.FirstName,
                        LastName = ep.Employee.LastName,
                        Email = ep.Employee.Emails
                            .Where(email => email.IsValid && email.IsApproved && !email.IsDeleted) // Filtreleme
                            .OrderBy(email => email.Id) // En eski e-posta öncelikli
                            .Select(email => email.Email)
                            .FirstOrDefault() ?? "No valid email"
                    }).ToList()
                })
                .FirstOrDefaultAsync(cancellationToken);

            return position ?? throw new KeyNotFoundException("Position not found");
        }
    }
}
