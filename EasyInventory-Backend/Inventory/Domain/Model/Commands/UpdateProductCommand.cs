namespace EasyInventory_Backend.Inventory.Domain.Model.Commands;

public record UpdateProductCommand(string Name,int UnitPrice,int RealPrice,int Discount,int Stock,int CurrentStock,int UserId);