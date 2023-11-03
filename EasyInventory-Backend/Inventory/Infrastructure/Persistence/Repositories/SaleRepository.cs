using EasyInventory_Backend.Inventory.Domain.Model.Aggregates;
using EasyInventory_Backend.Inventory.Domain.Repositories;
using EasyInventory_Backend.Shared.Infrastructure.Persistence.Configuration;
using EasyInventory_Backend.Shared.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EasyInventory_Backend.Inventory.Infrastructure.Persistence.Repositories;

public class SaleRepository : BaseRepository<Sale>,ISaleRepository
{
    public SaleRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Sale?> FindByNameAsync(string name)
    {
        return await Context.Set<Sale>()
            .FirstOrDefaultAsync(p => p.Name == name);
    }
}