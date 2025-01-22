using hris.Database;
using hris.Seed.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hris.Seed.Application.Service
{
    public class DepartmentService
    {
        private readonly AppDbContext _context;

        public DepartmentService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<List<Department>> GetAllDepartmentsWithPositionsAsync()
        {
            return await _context.Departments
                .Include(d => d.Positions)
                .ToListAsync();
        }
    }
}
