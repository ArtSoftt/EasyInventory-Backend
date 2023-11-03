using EasyInventory_Backend.Inventory.Domain.Model.Aggregates;
using EasyInventory_Backend.Inventory.Interfaces.REST.Resources;

namespace EasyInventory_Backend.Inventory.Interfaces.REST.Transform;

public static class ProviderResourceFromEntityAssembler
{

    public static ProviderResource ToResourceFromEntity(Provider provider)
    {
        return new ProviderResource(provider.Id, provider.Name, provider.Phone, provider.Ruc, provider.Email);
    }
}