using EasyInventory_Backend.Profiles.Domain.Model.Commands;
using EasyInventory_Backend.Profiles.Interfaces.REST.Resources;

namespace EasyInventory_Backend.Profiles.Interfaces.REST.Transform;

public class CreateProfileCommandFromResourceAssembler
{
    public static CreateProfileCommand ToCommandFromResource(CreateProfileResource resource)
    {
        return new CreateProfileCommand(resource.FirstName, resource.LastName, resource.Email, resource.Street,
            resource.City, resource.State, resource.ZipCode,resource.CompanyName);
    }
}