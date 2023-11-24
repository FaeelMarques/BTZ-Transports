using BTZTransports.Application.Areas.Identity.Data;
using BTZTransports.Application.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BTZTransports.Application.Data;

public class IdentityApplicationContext : IdentityDbContext<IdentityApplicationUser>
{
    public IdentityApplicationContext(DbContextOptions<IdentityApplicationContext> options)
        : base(options)
    {
    }

    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<FuelSupplyHistory> FuelSupplyHistory { get; set; }
    public DbSet<FuelTable> FuelTable { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }
}


public class ApplicationUserEntityConfiguration: IEntityTypeConfiguration<IdentityApplicationUser>
{
    public void Configure(EntityTypeBuilder<IdentityApplicationUser> builder)
    {
    }
 }