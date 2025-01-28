using hris.Security.Application.Dto;
using hris.Security.Application.Service;
using hris.Staff.Domain.Entities;

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
            var token = context.Request.Cookies["AuthToken"]; 

            Console.WriteLine("TOKEN --> " + token);

            using (var scope = serviceProvider.CreateScope())
            {
                var employeeTokenService = scope.ServiceProvider.GetRequiredService<EmployeeTokenService>();

                // if token is empty

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

                // validate employee token

                EmployeeTokenValidationResult validationResult = await employeeTokenService.ValidateToken(token); 

                // if token is valid

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

                // if token is not valid

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
