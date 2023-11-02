namespace EasyInventory_Backend.Profiles.Domain.Model.ValueObjects;

public record StreetAddress(string Street, string City, string State, string ZipCode)
{
    public StreetAddress() : this(string.Empty, string.Empty, string.Empty, String.Empty)
    {
        
    }

    public StreetAddress(string street) : this(street, string.Empty, string.Empty, string.Empty)
    {
        
    }

    public StreetAddress(string street, string city, string state) : this(street, city, state, string.Empty)
    {
        
    }

    public string FullAddres => $"{Street}, {City},{State},{ZipCode}";

}