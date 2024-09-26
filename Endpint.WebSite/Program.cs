using _04_06_01_ecommerce.Application.Interface.Context;
using _04_06_01_ecommerce.Application.Services.Users.Commands.RegisterUser;
using _04_06_01_ecommerce.Application.Services.Users.Commands.RemoveUser;
using _04_06_01_ecommerce.Application.Services.Users.Queries.GetRoles;
using _04_06_01_ecommerce.Application.Services.Users.Queries.GetUsers;
using _04_06_01_ecommerce.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddScoped<IGetUsersService, GetUserService>();
builder.Services.AddScoped<IGetRolesService, GetRolesService>();
builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();
builder.Services.AddScoped<IRemoveUserService, RemoveUserService>();

string connection = @"Data Source=DESKTOP-F91VCPQ; Initial Catalog=Store; Integrated Security=True; TrustServerCertificate=True;";

builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DataBaseContext>(option => option.UseSqlServer(connection));

builder.Services.AddControllersWithViews();

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

app.MapControllerRoute(
   name: "areas",
   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");



app.Run();
