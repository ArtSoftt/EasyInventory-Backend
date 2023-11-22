using EasyInventory_Backend.IAM.Domain.Aggregates;
using EasyInventory_Backend.Inventory.Domain.Model.Aggregates;
using EasyInventory_Backend.Profiles.Domain.Model.Aggregates;
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
                    
        // Sale Entity Configuration
        builder.Entity<Sale>().ToTable("Sales");
        builder.Entity<Sale>().HasKey(p => p.Id);
        builder.Entity<Sale>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Sale>().Property(p => p.Name).IsRequired();
        builder.Entity<Sale>().Property(p => p.SaleDate).IsRequired();
        builder.Entity<Sale>().Property(p => p.TotalCost).IsRequired();
        
        
        // Profile Entity Configuration
        builder.Entity<Profile>().ToTable("Profiles");
        builder.Entity<Profile>().HasKey(p => p.Id);
        builder.Entity<Profile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Profile>().OwnsOne(p=>p.Name,
        n =>
        {
            n.WithOwner().HasForeignKey("Id");
            n.Property(p => p.FirstName).HasColumnName("FirstName");
            n.Property(p => p.LastName).HasColumnName("LastName");
        });
        builder.Entity<Profile>().OwnsOne(p => p.Email,
            e =>
            {
                e.WithOwner().HasForeignKey("Id");
                e.Property(p => p.Address).HasColumnName("Email");
            });
        builder.Entity<Profile>().OwnsOne(p => p.Address,
            a =>
            {
                a.WithOwner().HasForeignKey("Id");
                a.Property(p => p.Street).HasColumnName("AddressStreet");
                a.Property(p => p.City).HasColumnName("AddressCity");
                a.Property(p => p.State).HasColumnName("AddressState");
                a.Property(p => p.ZipCode).HasColumnName("AddressZipCode");
            });
        //IAM context
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Username).IsRequired().HasMaxLength(30);
        builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
        // Profile Relationships
        builder.Entity<Profile>()
            .HasMany(c => c.Products)
            .WithOne(t => t.Profile)
            .HasForeignKey(t => t.ProfileId);
        
        // IAM Relationships
        builder.Entity<User>()
            .HasOne(e => e.Profile)
            .WithOne(e => e.User)
            .HasForeignKey<User>(e=>e.ProfileId);
        builder.UseSnakeCaseNamingConvention();
    }
}