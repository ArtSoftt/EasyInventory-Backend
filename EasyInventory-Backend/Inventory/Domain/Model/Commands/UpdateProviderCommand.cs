namespace EasyInventory_Backend.Inventory.Domain.Model.Commands;

public record UpdateProviderCommand(string Name,int Phone,long Ruc,string Email);