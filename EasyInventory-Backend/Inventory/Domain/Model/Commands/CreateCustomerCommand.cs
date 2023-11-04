namespace EasyInventory_Backend.Inventory.Domain.Model.Commands;

public record CreateCustomerCommand(string Name,string LastName,string Birthday, string Email,int Phone);