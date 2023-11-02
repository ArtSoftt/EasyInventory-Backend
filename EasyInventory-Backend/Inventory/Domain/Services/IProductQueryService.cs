using EasyInventory_Backend.Inventory.Domain.Model.Aggregates;
using EasyInventory_Backend.Inventory.Domain.Model.Queries;

namespace EasyInventory_Backend.Inventory.Domain.Services;

public interface IProductQueryService
{
    Task<Product?> Handle(GetProductByIdentifierQuery query);
    Task<IEnumerable<Product>> Handle(GetProductsByUserIdQuery query);
}