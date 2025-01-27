using hris.Database;
using hris.Seed.Domain.Entities;
using hris.Seed.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hris.Seed.Application.Service
{
    public class PhoneNumberTypeService
    {
        private readonly AppDbContext _context;

        public PhoneNumberTypeService(AppDbContext context)
        {
            _context = context;
        }



        public async Task<PhoneNumberType?> GetByNameOrThrowAsync(string name)
        {
            return await _context.PhoneNumberTypes.FirstOrDefaultAsync(p => p.Name == name);

        }


        public async Task<PhoneNumberType?> GetByIdOrThrowAsync(int id)
        {
            return await _context.PhoneNumberTypes.FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task<List<PhoneNumberType>> GetAllAsync()
        {
            return await _context.PhoneNumberTypes.ToListAsync();
        }
    }
}
