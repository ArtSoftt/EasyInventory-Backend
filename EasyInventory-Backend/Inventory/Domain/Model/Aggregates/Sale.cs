namespace EasyInventory_Backend.Inventory.Domain.Model.Aggregates;

public class Sale
{
   public int Id { get; set; }
   public string Name { get; set; }
   public string SaleDate { get; set; }
   public int TotalCost { get; set; }
   private ICollection<Product> Products;

   public Sale(string name, string saleDate, int totalCost)
   {
      Name = name;
      SaleDate = saleDate;
      TotalCost = totalCost;
   }
}