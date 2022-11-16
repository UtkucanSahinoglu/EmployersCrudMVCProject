using Business.Interface;
using Business.Service;
using DataAccess.ApiDbContext;
using DataAccess.Interface;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<EmployersDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmployerApiCoonnectionString")));

builder.Services.AddScoped<IEmployerService, EmployerService>();
builder.Services.AddScoped<IEmployerRepository, EmployerReposiyory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
