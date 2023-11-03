using EasyInventory_Backend.Inventory.Domain.Model.Aggregates;
using EasyInventory_Backend.Inventory.Domain.Model.Commands;

namespace EasyInventory_Backend.Inventory.Domain.Services;

public interface ISaleCommandService
{
    Task<Sale> Handle(CreateSaleCommand command);
    Task<Sale> Handle(DeleteSaleCommand command);
    Task<Sale> Handle(UpdateSaleCommand command);
}