namespace EasyInventory_Backend.Inventory.Domain.Model.Aggregates;

public class Provider
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Phone { get; set; }
    public long Ruc { get; set; }
    public string Email { get; set; }

    public Provider(string name, int phone, long ruc, string email)
    {
        Name = name;
        Phone = phone;
        Ruc = ruc;
        Email = email;
    }
    
}