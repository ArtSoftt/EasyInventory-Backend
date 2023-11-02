using EasyInventory_Backend.Inventory.Domain.Model.Commands;
using EasyInventory_Backend.Inventory.Interfaces.REST.Resources;

namespace EasyInventory_Backend.Inventory.Interfaces.REST.Transform;

public static class UpdateProductCommandFromResourceAssembler
{
    public static UpdateProductCommand ToCommandFromResource(CreateProductResource resource)
    {
        return new UpdateProductCommand(
            resource.Name, resource.UnitPrice, resource.RealPrice, resource.Discount, resource.Stock,
            resource.CurrentStock, resource.UserId);
    }
}