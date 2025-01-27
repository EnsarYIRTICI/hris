using hris.Database;
using hris.Seed.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hris.Seed.Application.Service
{
    public class CountryService
    {
        private readonly AppDbContext _context;

        public CountryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Country>> GetAllAsync()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country?> GetByIdAsync(int id)
        {
            return await _context.Countries.FindAsync(id);
        }

    }
}
