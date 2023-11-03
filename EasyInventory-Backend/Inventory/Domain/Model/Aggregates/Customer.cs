namespace EasyInventory_Backend.Inventory.Domain.Model.Aggregates;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Birthday { get; set; }
    public string Email { get; set; }
    public int Phone { get; set; }

    public Customer(string name, string lastName, string birthday, string email, int phone) 
    {
        
        Name = name;
        LastName = lastName;
        Birthday = birthday;
        Email = email;
        Phone = phone;
    }

}