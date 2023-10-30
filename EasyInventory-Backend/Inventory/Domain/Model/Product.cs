namespace EasyInventory_Backend.Inventory.Domain.Model;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public string Date { get; set; }
    public int Stock { get; set; }
    public int CurrentStock { get; set; }
    public int PriceToSell { get; set; }
    public int PriceToBuy { get; set; }
    
}