using EasyInventory_Backend.Inventory.Domain.Model.Aggregates;
using EasyInventory_Backend.Shared.Domain.Repositories;

namespace EasyInventory_Backend.Inventory.Domain.Repositories;

public interface ISaleRepository:IBaseRepository<Sale>
{
    Task<Sale?> FindByNameAsync(string name);
}