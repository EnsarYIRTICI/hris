using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using hris.Staff.Domain.Entities;
using hris.Staff.Application.Service;
using hris.Security.Application.Service;
using hris.Database;

namespace hris.Pages
{
    public class LoginModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly EmployeePasswordService _passwordService;
        private readonly TokenService _tokenService;

        public LoginModel(AppDbContext context, EmployeePasswordService passwordService, TokenService tokenService) 
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _passwordService = passwordService ?? throw new ArgumentNullException(nameof(passwordService));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));

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
                    .FirstOrDefault(p => p.EmployeeId == employeeEmail.EmployeeId && p.IsValid);

                if (employeePassword == null || !_passwordService.VerifyPasswordHash(Input.Password, employeePassword.PasswordHash, employeePassword.PasswordSalt))
                {
                    ErrorMessage = "Invalid email or password.";
                    return Page();
                }

                // Çalışan bilgilerini al
                var employee = _context.Employees.Find(employeeEmail.EmployeeId);

                // Token oluştur
             
                var token = _tokenService.GenerateToken(employee);

                Console.WriteLine("TOKEN --> ", token);

                // Token'ı cookie'ye ekle
                Response.Cookies.Append("AuthToken", token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    Expires = DateTime.UtcNow.AddDays(7),
                });

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
