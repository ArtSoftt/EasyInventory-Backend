namespace EasyInventory_Backend.Inventory.Domain.Model.Commands;

public record UpdateCustomerCommand(string Name,string LastName,string Birthday,string Email,int Phone);