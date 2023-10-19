using DevApplication1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<ProductDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("db")));
//builder.Services.AddDbContext<ProductDbContext>(options => options.UseMySql("Server=localhost;Database=db;User=root;Password=root;"));
//builder.Services.AddDbContextPool<MariaDbDbContext>(options => options
//        .UseMySql(
//            Configuration.GetConnectionString("MariaDbConnectionString"),
//            mySqlOptions => mySqlOptions.ServerVersion(new Version(10, 5, 4), ServerType.MariaDb)

builder.Services.AddDbContext<ProductDbContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("db"),
     ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("db")),
    builder =>
    {
        builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
    });
});
// Add services to the container.
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

app.Run();
