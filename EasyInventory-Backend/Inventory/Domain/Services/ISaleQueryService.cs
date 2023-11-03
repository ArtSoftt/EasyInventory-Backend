using EasyInventory_Backend.Inventory.Domain.Model.Aggregates;
using EasyInventory_Backend.Inventory.Domain.Model.Queries;

namespace EasyInventory_Backend.Inventory.Domain.Services;

public interface ISaleQueryService
{
    Task<Sale?> Handle(GetSaleByIdentifierQuery query);
}