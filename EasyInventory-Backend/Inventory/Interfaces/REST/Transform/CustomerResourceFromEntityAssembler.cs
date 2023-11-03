using EasyInventory_Backend.Inventory.Domain.Model.Aggregates;
using EasyInventory_Backend.Inventory.Interfaces.REST.Resources;

namespace EasyInventory_Backend.Inventory.Interfaces.REST.Transform;

public static class CustomerResourceFromEntityAssembler
{
    public static CustomerResource ToResourceFromEntity(Customer customer)
    {
        return new CustomerResource(customer.Id, customer.Name, customer.LastName, customer.Birthday, customer.Email,
            customer.Phone);
    }
}