namespace EasyInventory_Backend.Inventory.Interfaces.REST.Resources;

public record CreateCustomerResource(string Name,string LastName,string Birthday,string Email,int Phone);