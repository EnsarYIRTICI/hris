using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using hris.Staff.Domain.Entities;
using hris.Staff.Application.Service;
using hris.Database;
using hris.Staff.Domain.Exceptions;
using hris.Security.Application.Service;

namespace hris.Pages
{
    public class LoginModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly EmployeeService _employeeService;
        private readonly EmployeePasswordService _passwordService;
        private readonly EmployeeTokenService _tokenService;
        private readonly int _tokenLifetimeInDays;

        public LoginModel(
            IConfiguration configuration, 
            AppDbContext context,
            EmployeePasswordService passwordService,
            EmployeeTokenService tokenService,
            EmployeeService employeeService
            )
        {
            _tokenLifetimeInDays = int.Parse(configuration["TokenLifetimeInDays"] ?? "1");
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _passwordService = passwordService ?? throw new ArgumentNullException(nameof(passwordService));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            _employeeService = employeeService;
        }


        [BindProperty]
        public InputModel Input { get; set; }

        public string ErrorMessage { get; set; }

        public class InputModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {

            try {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                // E-Postayı doğrula
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
                var employee = await _employeeService.GetByIdAsync(employeeEmail.EmployeeId);

                // Token oluştur
                var token = await _tokenService.GenerateToken(employee);

                Console.WriteLine("TOKEN --> ", token);

                // Token'ı cookie'ye ekle
                Response.Cookies.Append("AuthToken", token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    Expires = DateTime.UtcNow.AddDays(_tokenLifetimeInDays),
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
