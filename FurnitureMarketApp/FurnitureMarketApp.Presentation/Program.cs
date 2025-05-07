using FurnitureMarketApp.Application.Services;
using FurnitureMarketApp.Domain.Interfaces;
using FurnitureMarketApp.Infrastructure.Data;
using FurnitureMarketApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IFurnitureItemService, FurnitureItemService>();
builder.Services.AddScoped<IOfferService, OfferService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IFavoriteService, FavoriteService>();

builder.Services.AddDbContext<FurnitureMarketContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), x => x.EnableRetryOnFailure()));
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
