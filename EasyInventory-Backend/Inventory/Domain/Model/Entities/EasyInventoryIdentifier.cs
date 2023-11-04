namespace EasyInventory_Backend.Inventory.Domain.Model.Entities;

public record EasyInventoryIdentifier(Guid Identifier)
{
    public EasyInventoryIdentifier() : this(Guid.NewGuid())
    {
        
    }
}