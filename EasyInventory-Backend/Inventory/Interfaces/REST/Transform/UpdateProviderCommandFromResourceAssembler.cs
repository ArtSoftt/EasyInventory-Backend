using EasyInventory_Backend.Inventory.Domain.Model.Commands;
using EasyInventory_Backend.Inventory.Interfaces.REST.Resources;

namespace EasyInventory_Backend.Inventory.Interfaces.REST.Transform;

public static class UpdateProviderCommandFromResourceAssembler
{
    public static UpdateProviderCommand ToCommandFromResource(CreateProviderResource resource)
    {
        return new UpdateProviderCommand(resource.Name, resource.Phone, resource.Ruc, resource.Email);
    }
    
}