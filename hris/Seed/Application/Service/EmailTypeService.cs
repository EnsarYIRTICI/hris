using hris.Database;
using hris.Seed.Domain.Entities;
using hris.Seed.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

public class EmailTypeService
{
    private readonly AppDbContext _context;

    public EmailTypeService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<EmailType?> GetByNameAsync(string name)
    {
        return await _context.EmailTypes.FirstOrDefaultAsync(e => e.Name == name);

    }


    public async Task<EmailType?> GetByIdAsync(int id)
    {
        return await _context.EmailTypes.FirstOrDefaultAsync(e => e.Id == id);

    }
 
    public async Task<List<EmailType>> GetAllAsync()
    {
        return await _context.EmailTypes.ToListAsync();
    }
}
