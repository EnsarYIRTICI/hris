using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using DotNetEnv;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace hris.Infrastructure.Security
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _secretKey;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;

            // .env dosyasını yükle
            DotNetEnv.Env.Load();

            // JWT secret keyini .env'den al
            _secretKey = DotNetEnv.Env.GetString("JWT_SECRET")
                         ?? throw new ArgumentException("JWT_SECRET is missing in the .env file.");
        }

        public async Task Invoke(HttpContext context)
        {
            var path = context.Request.Path;

            // Login isteği JWT doğrulaması gerektirmez
            if (path.StartsWithSegments("/account/login"))
            {
                await _next(context);
                return;
            }

            // Authorization header'dan token al
            var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            if (!string.IsNullOrEmpty(token))
            {
                // Token'ı doğrula
                if (ValidateToken(token, out ClaimsPrincipal principal))
                {
                    // Doğrulama başarılı ise kullanıcı bilgilerini bağlama ekle
                    context.User = principal;
                }
                else
                {
                    // Doğrulama başarısızsa login sayfasına yönlendir
                    context.Response.Redirect("/account/login");
                    return;
                }
            }
            else
            {
                // Token yoksa login sayfasına yönlendir
                context.Response.Redirect("/account/login");
                return;
            }

            await _next(context);
        }

        private bool ValidateToken(string token, out ClaimsPrincipal principal)
        {
            principal = null;

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_secretKey);

                // Token doğrulama parametrelerini ayarla
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false, // Gerekirse ayarla
                    ValidateAudience = false, // Gerekirse ayarla
                    ValidateLifetime = true, // Token süresini doğrula
                    ValidateIssuerSigningKey = true, // İmza anahtarını doğrula
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };

                // Token'ı doğrula
                principal = tokenHandler.ValidateToken(token, validationParameters, out _);
                return true;
            }
            catch
            {
                // Token geçersizse false döner
                return false;
            }
        }
    }
}
