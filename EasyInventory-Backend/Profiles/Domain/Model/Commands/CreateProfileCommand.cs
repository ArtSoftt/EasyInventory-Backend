namespace EasyInventory_Backend.Profiles.Domain.Model.Commands;

public record CreateProfileCommand(string FirstName,string LastName,string Email,string Street,string City,string State,string ZipCode,string CompanyName);