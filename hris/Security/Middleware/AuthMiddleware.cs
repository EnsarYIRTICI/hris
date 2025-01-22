
using hris.Security.Application.Service;

namespace hris.Security.Middleware
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IServiceProvider serviceProvider)
        {
            var path = context.Request.Path;
            // var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var token = context.Request.Cookies["AuthToken"];

            Console.WriteLine("TOKEN --> " + token);

            // Scoped servis olan TokenService'e IServiceProvider üzerinden erişim sağlanıyor
            using (var scope = serviceProvider.CreateScope())
            {
                var tokenService = scope.ServiceProvider.GetRequiredService<TokenService>();

                if (string.IsNullOrEmpty(token))
                {
                    if (path.StartsWithSegments("/account/login"))
                    {
                        await _next(context);
                    }
                    else
                    {
                        context.Response.Redirect("/account/login");
                    }
                    return;
                }

                var validationResult = await tokenService.ValidateToken(token);

                if (validationResult.IsValid)
                {
                    context.Items["Employee"] = validationResult.Employee;
                    context.User = validationResult.Principal;

                    if (path.StartsWithSegments("/account/login"))
                    {
                        context.Response.Redirect("/");
                    }
                    else
                    {
                        await _next(context);
                    }
                    return;
                }

                Console.WriteLine("Error Message --> " + validationResult.ErrorMessage);

                if (path.StartsWithSegments("/account/login"))
                {
                    await _next(context);
                }
                else
                {
                    context.Response.Redirect("/account/login");
                }
            }
        }
    }
}
