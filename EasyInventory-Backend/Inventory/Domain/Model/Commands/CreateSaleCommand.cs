namespace EasyInventory_Backend.Inventory.Domain.Model.Commands;

public record CreateSaleCommand(string Name,string SaleDate,int TotalCost);