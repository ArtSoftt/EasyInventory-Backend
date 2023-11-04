using EasyInventory_Backend.Inventory.Domain.Model.Aggregates;
using EasyInventory_Backend.Shared.Domain.Repositories;

namespace EasyInventory_Backend.Inventory.Domain.Repositories;

public interface IProductRepository: IBaseRepository<Product>
{
    Task<IEnumerable<Product>> FindByUserIdAsync(int userId);
    Task<Product?> FindByNameAsync(string name);
}