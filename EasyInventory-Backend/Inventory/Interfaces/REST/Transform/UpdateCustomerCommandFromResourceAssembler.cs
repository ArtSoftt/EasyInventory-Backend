using EasyInventory_Backend.Inventory.Domain.Model.Commands;
using EasyInventory_Backend.Inventory.Interfaces.REST.Resources;

namespace EasyInventory_Backend.Inventory.Interfaces.REST.Transform;

public class UpdateCustomerCommandFromResourceAssembler
{
    public static UpdateCustomerCommand ToCommandFromResource(CreateCustomerResource resource)
    {
        return new UpdateCustomerCommand(resource.Name, resource.LastName, resource.Birthday, resource.Email,
            resource.Phone);
    }
}