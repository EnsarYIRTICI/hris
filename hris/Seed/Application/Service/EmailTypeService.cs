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

    public async Task<EmailType> GetByNameOrThrowAsync(string name)
    {
        var email = await _context.EmailTypes.FirstOrDefaultAsync(e => e.Name == name);

        if (email == null)
        {
            throw new EmailTypeNotFoundException();
        }
        return email;
    }

    public async Task<EmailType> GetPersonalAsync()
    {
        return await GetByNameOrThrowAsync("Personal");
    
    }


    public async Task<EmailType> GetWorkAsync()
    {
        return await GetByNameOrThrowAsync("Work");
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
