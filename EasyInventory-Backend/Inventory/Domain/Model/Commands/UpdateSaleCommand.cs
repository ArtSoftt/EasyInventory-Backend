namespace EasyInventory_Backend.Inventory.Domain.Model.Commands;

public record UpdateSaleCommand(string Name,string SaleDate,int TotalCost);