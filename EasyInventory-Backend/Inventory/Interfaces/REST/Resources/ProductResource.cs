using EasyInventory_Backend.Profiles.Interfaces.REST.Resources;

namespace EasyInventory_Backend.Inventory.Interfaces.REST.Resources;

public record ProductResource(int Id, string Name, int UnitPrice,int RealPrice, int Discount,int Stock,int CurrentStock,int ProfileId,string Category);