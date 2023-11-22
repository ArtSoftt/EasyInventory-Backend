using EasyInventory_Backend.IAM.Domain.Aggregates;
using EasyInventory_Backend.Inventory.Domain.Model.Aggregates;
using EasyInventory_Backend.Profiles.Domain.Model.ValueObjects;
namespace EasyInventory_Backend.Profiles.Domain.Model.Aggregates;

public  partial class Profile
{
    public int Id { get; set; }
    public PersonName Name { get; private set; }
    public EmailAddress Email { get; private set; }
    public ICollection<Product> Products { get; }
    public User? User { get; set; }
    public StreetAddress Address { get; private set; }
    public string CompanyName { get; set; }

    public Profile(string firstName, string lastName, string email, string street, string city, string state,
        string zipCode,string companyName):this()
    {
        CompanyName = companyName;
        Name = new PersonName(firstName, lastName);
        Email = new EmailAddress(email);
        Address = new StreetAddress(street, city, state, zipCode);
    }

    public Profile()
    {
        Name = new PersonName();
        Email = new EmailAddress();
        Address = new StreetAddress();
    }
}