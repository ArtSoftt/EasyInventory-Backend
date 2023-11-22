namespace EasyInventory_Backend.Profiles.Interfaces.REST.Resources;

public record CreateProfileResource(string FirstName,string LastName,string Email,string Street,string City,string State,string ZipCode,string CompanyName);