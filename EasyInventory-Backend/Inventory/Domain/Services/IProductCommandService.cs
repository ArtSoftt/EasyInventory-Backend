using EasyInventory_Backend.Inventory.Domain.Model.Aggregates;
using EasyInventory_Backend.Inventory.Domain.Model.Commands;

namespace EasyInventory_Backend.Inventory.Domain.Services;

public interface IProductCommandService
{
   Task<Product> Handle(CreateProductCommand command);
   Task<Product> Handle(UpdateProductCommand command);
   Task<Product> Handle(DeleteProductCommand command);
}