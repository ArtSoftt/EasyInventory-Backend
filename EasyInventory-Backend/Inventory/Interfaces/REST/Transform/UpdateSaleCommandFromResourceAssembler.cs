using EasyInventory_Backend.Inventory.Domain.Model.Commands;
using EasyInventory_Backend.Inventory.Interfaces.REST.Resources;

namespace EasyInventory_Backend.Inventory.Interfaces.REST.Transform;

public static class UpdateSaleCommandFromResourceAssembler
{
    public static UpdateSaleCommand ToCommandFromResource(CreateSaleResource resource)
    {
        return new UpdateSaleCommand(resource.Name, resource.SaleDate, resource.TotalCost);
    }
}