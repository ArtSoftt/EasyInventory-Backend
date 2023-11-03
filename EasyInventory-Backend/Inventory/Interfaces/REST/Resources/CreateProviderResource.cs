namespace EasyInventory_Backend.Inventory.Interfaces.REST.Resources;

public record CreateProviderResource(string Name,int Phone,long Ruc,string Email);