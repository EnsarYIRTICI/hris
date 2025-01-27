namespace hris.Security.Middleware
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next; // Middleware'in bir sonraki adıma geçmesi için kullanılır.
        }

        public async Task Invoke(HttpContext context, IServiceProvider serviceProvider)
        {
            var path = context.Request.Path; // İstek yapılan yolu alır.
            var token = context.Request.Cookies["AuthToken"]; // AuthToken cookie'sinden token alınır.

            Console.WriteLine("TOKEN --> " + token);

            using (var scope = serviceProvider.CreateScope())
            {
                var employeeTokenService = scope.ServiceProvider.GetRequiredService<EmployeeTokenService>();

                if (string.IsNullOrEmpty(token)) // Token boş ise kontrol yapılır.
                {
                    if (path.StartsWithSegments("/account/login")) // Login sayfasına erişim sağlanıyorsa devam edilir.
                    {
                        await _next(context);
                    }
                    else // Aksi halde login sayfasına yönlendirilir.
                    {
                        context.Response.Redirect("/account/login");
                    }
                    return;
                }

                var validationResult = await employeeTokenService.ValidateToken(token); // Token doğrulanır.

                if (validationResult.IsValid) // Token geçerliyse kullanıcı bilgileri eklenir.
                {
                    context.Items["Employee"] = validationResult.Employee;
                    context.User = validationResult.Principal;

                    if (path.StartsWithSegments("/account/login")) // Login sayfasındaysa ana sayfaya yönlendirilir.
                    {
                        context.Response.Redirect("/");
                    }
                    else // Aksi halde bir sonraki middleware'e geçilir.
                    {
                        await _next(context);
                    }
                    return;
                }

                Console.WriteLine("Error Message --> " + validationResult.ErrorMessage);

                if (path.StartsWithSegments("/account/login")) // Geçersiz token ile login sayfasında devam edilir.
                {
                    await _next(context);
                }
                else // Geçersiz token ile login sayfasına yönlendirilir.
                {
                    context.Response.Redirect("/account/login");
                }
            }
        }

    }

}
