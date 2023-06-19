using BusinessLayer.Repositories;
using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//Database connection
builder.Services.AddDbContext<SQLContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("sqlconnection")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(SQLRepository<>)); // IRepository yazýlan yerleri, SQLRepository ile deðiþtir.

//Cookie Builder
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/admin/giris";
    options.LogoutPath = "/admin/cikis";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); //Kimlik Yetkilendirme

app.UseAuthorization(); //Kimlik Doðrulama


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=index}/{id?}");

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=home}/{action=index}/{id?}");

app.Run();
