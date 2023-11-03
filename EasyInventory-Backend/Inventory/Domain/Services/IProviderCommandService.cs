using EasyInventory_Backend.Inventory.Domain.Model.Aggregates;
using EasyInventory_Backend.Inventory.Domain.Model.Commands;

namespace EasyInventory_Backend.Inventory.Domain.Services;

public interface IProviderCommandService
{
    Task<Provider> Handle(CreateProviderCommand command);
    Task<Provider> Handle(UpdateProviderCommand command);
    Task<Provider> Handle(DeleteProviderCommand command);
}