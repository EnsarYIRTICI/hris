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


        private async Task<Position> GetByNameOrThrowAsync(string name)
        {
            var position = await _context.Positions.FirstOrDefaultAsync(p => p.Name == name);
            if (position == null)
            {
                throw new PositionNotFoundException(name);
            }
            return position;
        }


        public async Task<Position> GetAdminPositionAsync()
        {
            return await GetByNameOrThrowAsync("Yönetici");
        }


        public async Task<Position> GetSoftwareDeveloperPositionAsync()
        {
            return await GetByNameOrThrowAsync("Software Developer");
        }


        public async Task<List<Position>> GetAllAsync()
        {
            return await _context.Positions.Include(p => p.Department).ToListAsync();
        }
    }

}
