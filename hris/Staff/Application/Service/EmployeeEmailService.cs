using hris.Database;
using hris.Staff.Domain.Entities;
using hris.Staff.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace hris.Staff.Application.Service
{
    public class EmployeeEmailService
    {

        private readonly AppDbContext _context;

        public EmployeeEmailService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<EmployeeEmail> GetValidEmailsAsync(Employee employee)
        {
            var validatedEmail = await _context.EmployeeEmails.FirstOrDefaultAsync(e => e.Employee == employee && e.IsValid);

            if (validatedEmail == null)
            {
                throw new ValidatedEmailNotFoundException();
            }

            return validatedEmail;

        }
    }
}
