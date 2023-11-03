using EasyInventory_Backend.Inventory.Domain.Model.Aggregates;
using EasyInventory_Backend.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EasyInventory_Backend.Shared.Infrastructure.Persistence.Configuration;

public class AppDbContext :DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        //Enable Created/Updated Interceptor
        base.OnConfiguring(builder);
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //Publishing Context
        //Product Entity Configuration
        builder.Entity<Product>().ToTable("Products");
        builder.Entity<Product>().HasKey(p => p.Id);
        builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Entity<Product>().Property(p => p.UnitPrice).IsRequired().HasMaxLength(10);
        builder.Entity<Product>().Property(p => p.RealPrice).IsRequired().HasMaxLength(10);
        builder.Entity<Product>().Property(p => p.Stock).IsRequired().HasMaxLength(10);
        builder.Entity<Product>().Property(p => p.CurrentStock).IsRequired().HasMaxLength(10);
        builder.Entity<Product>().Property(p => p.UserId).IsRequired().HasMaxLength(10);
        builder.Entity<Product>().Property(p => p.Discount).IsRequired().HasMaxLength(10);
        //Customer Entity Configuration
        builder.Entity<Customer>().ToTable("Customers");
        builder.Entity<Customer>().HasKey(p => p.Id);
        builder.Entity<Customer>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Customer>().Property(p => p.Birthday).IsRequired();
        builder.Entity<Customer>().Property(p => p.Email).IsRequired();
        builder.Entity<Customer>().Property(p => p.Name).IsRequired();
        builder.Entity<Customer>().Property(p => p.LastName).IsRequired();
        builder.Entity<Customer>().Property(p => p.Phone).IsRequired();
        //Provider Entity Configuration
        builder.Entity<Provider>().ToTable("Providers");
        builder.Entity<Provider>().HasKey(p => p.Id);
        builder.Entity<Provider>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Provider>().Property(p => p.Name).IsRequired();
        builder.Entity<Provider>().Property(p => p.Email).IsRequired();
        builder.Entity<Provider>().Property(p => p.Phone).IsRequired();
        builder.Entity<Provider>().Property(p => p.Ruc).IsRequired();
                    
        //Asset Entity Configuration
        //Apply snake Case naming convention
        
        builder.UseSnakeCaseNamingConvention();
    }
}