using EasyInventory_Backend.Inventory.Domain.Model.Aggregates;
using EasyInventory_Backend.Inventory.Domain.Repositories;
using EasyInventory_Backend.Shared.Infrastructure.Persistence.Configuration;
using EasyInventory_Backend.Shared.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EasyInventory_Backend.Inventory.Infrastructure.Persistence.Repositories;

public class ProductRepository:BaseRepository<Product>,IProductRepository
{
    private IProductRepository _productRepositoryImplementation;

    public ProductRepository(AppDbContext context) : base(context)
    {
        
    }

    public async Task<IEnumerable<Product>> FindByUserIdAsync(int userId)
    {
        return await Context.Set<Product>()
            .Where(product => product.UserId == userId)
            .ToListAsync();
    }

    public async Task<Product?> FindByNameAsync(string name)
    {
        
        return await Context.Set<Product>()
            .FirstOrDefaultAsync(product => product.Name == name);
    }

    
}