namespace EasyInventory_Backend.Inventory.Domain.Model.Entities;

public partial class Asset
{
    protected Asset()
    {
        AssetIdentifier = new EasyInventoryIdentifier();
    }
    public int Id { get; private set; }
    public EasyInventoryIdentifier AssetIdentifier { get; private set; }

    public virtual object GetContent()
    {
        return string.Empty;
    }
}