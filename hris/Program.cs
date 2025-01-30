using hris.Database;
using hris.Security.Middleware;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using MediatR;
using hris.Security.Application.Service;
using hris.Seed.Application.Service;
using hris.Hubs;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddAuthorization();
builder.Services.AddRazorPages();
builder.Services.AddSession();
builder.Services.AddSignalR();
builder.Services.AddHttpContextAccessor();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.AddScoped<EmployeeTokenService>();
builder.Services.AddScoped<SeedService>();

var app = builder.Build();

app.UseMiddleware<AuthMiddleware>();

using (var scope = app.Services.CreateScope())
{
    var seedService = scope.ServiceProvider.GetRequiredService<SeedService>();
    await seedService.SeedAdminEmployeeAsync();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}


app.UseStatusCodePagesWithReExecute("/Error/Error404");

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseSession();

app.MapHub<EmployeeHub>("/employeeHub");
app.MapHub<DepartmentHub>("/departmentHub");

app.MapRazorPages();

app.Run();
