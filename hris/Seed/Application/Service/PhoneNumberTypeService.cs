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



        public async Task<PhoneNumberType> GetMobileAsync()
        {
            return await GetByNameOrThrowAsync("Mobile");
        }

        public async Task<PhoneNumberType> GetWorkAsync()
        {
            return await GetByNameOrThrowAsync("Work");
        }

        public async Task<PhoneNumberType> GetHomeAsync()
        {
            return await GetByNameOrThrowAsync("Home");
        }

        public async Task<PhoneNumberType> GetByNameOrThrowAsync(string name)
        {
            var phoneNumberType = await _context.PhoneNumberTypes.FirstOrDefaultAsync(p => p.Name == name);
            if (phoneNumberType == null)
            {
                throw new PhoneNumberTypeNotFoundException($"PhoneNumberType with name '{name}' not found.");
            }
            return phoneNumberType;
        }


        public async Task<PhoneNumberType> GetByIdOrThrowAsync(int id)
        {
            var phoneNumberType = await _context.PhoneNumberTypes.FirstOrDefaultAsync(p => p.Id == id);
            if (phoneNumberType == null)
            {
                throw new PhoneNumberTypeNotFoundException($"PhoneNumberType with id '{id}' not found.");
            }
            return phoneNumberType;
        }


        public async Task<List<PhoneNumberType>> GetAllAsync()
        {
            return await _context.PhoneNumberTypes.ToListAsync();
        }
    }
}
