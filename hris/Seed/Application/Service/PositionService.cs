using hris.Seed.Domain.Exceptions;
using hris.Seed.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using hris.Database;
using hris.Staff.Domain.Entities;
using hris.DepartmentModule.Domain.Entities;

namespace hris.Seed.Application.Service
{
    public class PositionService
    {
        private readonly AppDbContext _context;

        public PositionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Position> GetAdminPositionAsync()
        {
            return await GetByNameOrThrowAsync("Yönetici");
        }


        public async Task<Position> GetSoftwareDeveloperPositionAsync()
        {
            return await GetByNameOrThrowAsync("Software Developer");
        }

        public async Task<int> GetTotalPositionsAsync()
        {
            return await _context.Positions.CountAsync();
        }


        public async Task<List<Position>> GetAllSameDepartmentPositionsByIdAsync(int positionId)
        {
            var position = await _context.Positions
                .Include(p=>p.Department)
                .FirstOrDefaultAsync(p => p.Id == positionId);

            if (position == null)
            {
                throw new PositionNotFoundException(positionId);
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


        private async Task<Position> GetByNameOrThrowAsync(string name)
        {
            var position = await _context.Positions.FirstOrDefaultAsync(p => p.Name == name);
            if (position == null)
            {
                throw new PositionNotFoundException(name);
            }
            return position;
        }

        public async Task<Position> GetByIdThrowAsync(int positionId)
        {
            var position = await _context.Positions.FirstOrDefaultAsync(p => p.Id == positionId);
            if (position == null)
            {
                throw new PositionNotFoundException(positionId);
            }
            return position;
        }

        public async Task<List<Position>> GetAllAsync()
        {
            return await _context.Positions.Include(p => p.Department).ToListAsync();
        }


    }

}
