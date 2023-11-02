namespace EasyInventory_Backend.Inventory.Domain.Model.Aggregates;

public  class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int UnitPrice { get; set; }
    public int RealPrice { get; set; }
    public int Discount { get; set; }
    public int Stock { get; set; }
    public int CurrentStock { get; set; }
    public int UserId { get; private set; }

    public Product(string name, int unitPrice, int realPrice, int discount, int stock, int currentStock,
        int userId)
    {
        Name = name;
        UnitPrice = unitPrice;
        RealPrice = realPrice;
        Discount = discount;
        Stock = stock;
        CurrentStock = currentStock;
        UserId = userId;
    }
    
    
}