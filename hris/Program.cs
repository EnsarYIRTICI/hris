using hris.Database;
using hris.Security.Application.Command;
using hris.Security.Middleware;
using hris.Seed.Application.Service;
using hris.Staff.Application.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using MediatR;
using AutoMapper;
using hris.Division.Application.Service;
using hris.Security.Application.Service;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning);

builder.Services.AddScoped<EmployeeTokenService>();

builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<EmployeeEmailService>();
builder.Services.AddScoped<EmployeePasswordService>();

builder.Services.AddScoped<DepartmentService>();
builder.Services.AddScoped<PositionService>();

builder.Services.AddScoped<SeedService>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


builder.Services.AddAuthorization();
builder.Services.AddRazorPages();
builder.Services.AddSession();

builder.Services.AddHttpContextAccessor();

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var seedService = scope.ServiceProvider.GetRequiredService<SeedService>();
    await seedService.SeedAdminEmployeeAsync();
}

app.UseMiddleware<AuthMiddleware>();

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

app.MapRazorPages();

app.Run();
