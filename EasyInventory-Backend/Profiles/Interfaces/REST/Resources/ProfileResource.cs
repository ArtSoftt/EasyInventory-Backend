using EasyInventory_Backend.IAM.Domain.Aggregates;
using EasyInventory_Backend.IAM.Interfaces.REST.Resources;

namespace EasyInventory_Backend.Profiles.Interfaces.REST.Resources;

public record ProfileResource(int Id,string FirstName,string LastName,string Email,string Street,string City,string State,string ZipCode,string CompanyName);