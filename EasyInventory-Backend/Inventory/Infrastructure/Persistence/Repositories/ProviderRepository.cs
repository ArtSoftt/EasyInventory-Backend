using EasyInventory_Backend.Inventory.Domain.Model.Aggregates;
using EasyInventory_Backend.Inventory.Domain.Repositories;
using EasyInventory_Backend.Shared.Infrastructure.Persistence.Configuration;
using EasyInventory_Backend.Shared.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EasyInventory_Backend.Inventory.Infrastructure.Persistence.Repositories;

public class ProviderRepository: BaseRepository<Provider>,IProviderRepository
{
    public ProviderRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Provider?> FindByNameAsync(string name)
    {
        return await Context.Set<Provider>()
            .FirstOrDefaultAsync(provider => provider.Name == name);
    }
}