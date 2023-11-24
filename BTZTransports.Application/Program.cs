using BTZTransports.Application.Areas.Identity.Data;
using BTZTransports.Application.Data;
using BTZTransports.Application.Repositories;
using BTZTransports.Application.Repositories.Interfaces;
using BTZTransports.Application.Services;
using BTZTransports.Application.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("BTZTransportsApplicationContextConnection") ?? throw new InvalidOperationException("Connection string 'BTZTransportsApplicationContextConnection' not found.");

builder.Services.AddDbContext<IdentityApplicationContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<IdentityApplicationContext>();

builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<IFuelSupplyHistoryService, FuelSupplyHistoryService>();

builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IFuelSupplyHistoryRepository, FuelSupplyHistoryRepository>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
