
using hris.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using hris.Staff.Domain.Entities;
using hris.Staff.Infrastructure.Service;

namespace hris.Pages
{   
    public class LoginModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly EmployeePasswordService _passwordService;


        public LoginModel(AppDbContext context, EmployeePasswordService passwordService) 
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _passwordService = passwordService ?? throw new ArgumentNullException(nameof(passwordService));

        }


        [BindProperty]
        public InputModel Input { get; set; }

        public string ErrorMessage { get; set; }

        public class InputModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public IActionResult OnPost()
        {

            try {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                // Kullanıcının giriş bilgilerini kontrol etmek
                var employeeEmail = _context.EmployeeEmails
                        .FirstOrDefault(e => e.Email == Input.Email && e.IsValid);

                if (employeeEmail == null)
                {
                    ErrorMessage = "Invalid email or password.";
                    return Page();
                }

                // Şifreyi doğrula
                var employeePassword = _context.EmployeePasswords
                    .LastOrDefault(p => p.EmployeeId == employeeEmail.EmployeeId);

                if (employeePassword == null || !_passwordService.VerifyPasswordHash(Input.Password, employeePassword.PasswordHash, employeePassword.PasswordSalt))
                {
                    ErrorMessage = "Invalid email or password.";
                    return Page();
                }

                // Giriş başarılı, ana sayfaya yönlendir
                return RedirectToPage("/Index");
            }
            catch (Exception ex) {
                ErrorMessage = ex.Message;
                return Page();
            }


        }

  

    }
}
