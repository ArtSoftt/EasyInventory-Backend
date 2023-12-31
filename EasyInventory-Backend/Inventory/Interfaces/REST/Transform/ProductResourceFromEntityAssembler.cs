using EasyInventory_Backend.Inventory.Domain.Model.Aggregates;
using EasyInventory_Backend.Inventory.Interfaces.REST.Resources;

namespace EasyInventory_Backend.Inventory.Interfaces.REST.Transform;

public static class ProductResourceFromEntityAssembler
{
    public static ProductResource ToResourceFromEntity(Product product)
    {
        return new ProductResource(product.Id, product.Name, product.UnitPrice, product.RealPrice, product.Discount,
            product.Stock, product.CurrentStock, product.UserId);
    }
}