using EasyInventory_Backend.Inventory.Domain.Model.Aggregates;
using EasyInventory_Backend.Inventory.Interfaces.REST.Resources;

namespace EasyInventory_Backend.Inventory.Interfaces.REST.Transform;

public static class SaleResourceFromEntityAssembler
{
    public static SaleResource ToResourceFromEntity(Sale sale)
    {
        return new SaleResource(sale.Id, sale.Name, sale.SaleDate, sale.TotalCost);
    }
}