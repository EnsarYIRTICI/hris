using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using hris.Security.Application.Query;

namespace hris.Pages.Account.Login
{
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly int _tokenLifetimeInDays;

        public IndexModel(IConfiguration configuration, IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _tokenLifetimeInDays = int.Parse(configuration["TokenLifetimeInDays"] ?? "1");
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }


        public string ErrorMessage { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                var token = await _mediator.Send(new LoginQuery(Input.Email, Input.Password));

                Response.Cookies.Append("AuthToken", token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    Expires = DateTime.UtcNow.AddDays(_tokenLifetimeInDays),
                });

                return RedirectToPage("/Index");
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return Page();
            }
        }
    }
}
