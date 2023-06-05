using Microsoft.EntityFrameworkCore;
using Spg.KaufMyStuff.DomainModel.Services;
using Spg.KaufMyStuff.DomainModel.Services.Products;
using Spg.KaufMyStuff.DomainModel.Interfaces;
using Spg.KaufMyStuff.DomainModel.Models;
using Spg.KaufMyStuff.Infrastructure;
using Spg.KaufMyStuff.Repositories;
using System.Reflection;
using Spg.KaufMyStuff.DomainModel;
using Spg.KaufMyStuff.MvcFrontEnd.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddEd("Data Source=KaufMyStuff.db");
builder.Services.AddKmSRepositories();
builder.Services.AddKmSServices();

builder.Services.AddTransient<HttpAuthService>();
builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();




// ACHTUNG!!! Wegwerf-Code:
DbContextOptionsBuilder options = new DbContextOptionsBuilder();
options.UseSqlite("Data Source=KaufMyStuff.db");
KaufMyStuffContext db = new KaufMyStuffContext(options.Options);
db.Database.EnsureDeleted();
db.Database.EnsureCreated();
db.Seed();
// ACHTUNG!!! Wegwerf-Code:





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
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
