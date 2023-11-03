namespace EasyInventory_Backend.Inventory.Domain.Model.Commands;

public record CreateProviderCommand(string Name,int Phone,long Ruc,string Email);