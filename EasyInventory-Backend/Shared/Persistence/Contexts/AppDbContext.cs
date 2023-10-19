using EasyInventory_Backend.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
namespace EasyInventory_Backend.Shared.Persistence.Contexts;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options){ }

    protected override void onModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.UseSnakeCaseNamingConvention();
    }
}