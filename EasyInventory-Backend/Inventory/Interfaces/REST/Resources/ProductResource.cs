namespace EasyInventory_Backend.Inventory.Interfaces.REST.Resources;

public record ProductResource(int Id, string Name, int UnitPrice,int RealPrice, int Discount,int Stock,int CurrentStock,int UserId);