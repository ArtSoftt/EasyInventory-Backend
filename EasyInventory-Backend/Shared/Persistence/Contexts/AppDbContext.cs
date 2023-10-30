using EasyInventory_Backend.Shared.Extensions;
using EasyInventory_Backend.Inventory.Domain.Model;
using Microsoft.EntityFrameworkCore;
namespace EasyInventory_Backend.Shared.Persistence.Contexts;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options){ }
    public DbSet<Product> Products { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Product>().ToTable("Products");
        builder.Entity<Product>().HasKey(c => c.Id);
        builder.Entity<Product>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Product>().Property(c => c.Name).IsRequired().HasMaxLength(30);
        builder.Entity<Product>().Property(c => c.Category).IsRequired().HasMaxLength(30);
        builder.Entity<Product>().Property(c => c.CurrentStock).IsRequired();
        builder.Entity<Product>().Property(c => c.Stock).IsRequired();
        builder.Entity<Product>().Property(c => c.PriceToBuy).IsRequired();
        builder.Entity<Product>().Property(c => c.PriceToSell).IsRequired();
        builder.Entity<Product>().Property(c => c.Date).IsRequired().HasMaxLength(10);
        builder.UseSnakeCaseNamingConvention();
    }
}