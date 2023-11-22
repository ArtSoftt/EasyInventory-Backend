using EasyInventory_Backend.Profiles.Domain.Model.Aggregates;

namespace EasyInventory_Backend.Inventory.Domain.Model.Aggregates;

public  class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int UnitPrice { get; set; }
    public string Category { get; set; }
    public int RealPrice { get; set; }
    public int Discount { get; set; }
    public int Stock { get; set; }
    public int CurrentStock { get; set; }
    public Profile Profile { get; }
    public int ProfileId { get; private set; }

    public Product()
    {
        Name = string.Empty;
        Category = string.Empty;
    }

    public Product(string name, int unitPrice, int realPrice, int discount, int stock, int currentStock,
        int profileId,string category):this()
    {
        Name = name;
        UnitPrice = unitPrice;
        RealPrice = realPrice;
        Discount = discount;
        Stock = stock;
        CurrentStock = currentStock;
        ProfileId = profileId;
        Category = category;
    }
    
    
}