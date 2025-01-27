using hris.Seed.Domain.Exceptions;
using hris.Seed.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using hris.Database;

namespace hris.Seed.Application.Service
{
    public class PositionService
    {
        private readonly AppDbContext _context;

        public PositionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _context.Positions.CountAsync();
        }


        public async Task<List<Position>?> GetAllSameDepartmentPositionsByIdAsync(int positionId)
        {
            var position = await _context.Positions
                .Include(p=>p.Department)
                .FirstOrDefaultAsync(p => p.Id == positionId);

            if (position == null)
            {
                return null;
            }

            return await GetAllByDepartmentIdAsync(position.DepartmentId);
        }

        public async Task<List<Position>> GetAllByDepartmentIdAsync(int departmentId)
        {
            return await _context.Positions
                .Where(d=>d.DepartmentId == departmentId)
                .Include(p => p.Department)
                .ToListAsync();
        }


        public async Task<Position?> GetByNameAsync(string name)
        {
            return await _context.Positions.FirstOrDefaultAsync(p => p.Name == name);
    
        }

        public async Task<Position?> GetByIdAsync(int positionId)
        {
            return await _context.Positions.FirstOrDefaultAsync(p => p.Id == positionId);
       
        }

        public async Task<List<Position>> GetAllAsync()
        {
            return await _context.Positions.Include(p => p.Department).ToListAsync();
        }


    }

}
