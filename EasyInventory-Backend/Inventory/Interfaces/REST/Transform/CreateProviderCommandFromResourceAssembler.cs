using EasyInventory_Backend.Inventory.Domain.Model.Commands;
using EasyInventory_Backend.Inventory.Interfaces.REST.Resources;

namespace EasyInventory_Backend.Inventory.Interfaces.REST.Transform;

public static class CreateProviderCommandFromResourceAssembler
{
    public static CreateProviderCommand ToCommandFromResource(CreateProviderResource resource)
    {
        return new CreateProviderCommand(resource.Name, resource.Phone, resource.Ruc, resource.Email);
    }
}