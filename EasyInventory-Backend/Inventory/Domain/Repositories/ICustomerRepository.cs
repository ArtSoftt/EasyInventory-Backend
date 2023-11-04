using EasyInventory_Backend.Inventory.Domain.Model.Aggregates;
using EasyInventory_Backend.Shared.Domain.Repositories;

namespace EasyInventory_Backend.Inventory.Domain.Repositories;

public interface ICustomerRepository : IBaseRepository<Customer>
{
    Task<Customer?> FindByNameAsync(string name);
}