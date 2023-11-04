namespace EasyInventory_Backend.Inventory.Domain.Model.Entities;

public class ImageAsset :Asset
{
    public Uri ImageUri { get; }

    public ImageAsset(string imageUrl)
    {
        ImageUri = new Uri(imageUrl);
    }

    public override string GetContent()
    {
        return ImageUri.AbsoluteUri;
    }
}