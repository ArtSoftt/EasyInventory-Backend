using EasyInventory_Backend.Profiles.Domain.Model.Aggregates;
using EasyInventory_Backend.Profiles.Interfaces.REST.Resources;

namespace EasyInventory_Backend.Profiles.Interfaces.REST.Transform;

public static class ProfileResourceFromEntityAssembler
{
    public static ProfileResource ToResourceFromEntity(Profile profile)
    {
        return new ProfileResource(profile.Id, profile.Name.FirstName, profile.Name.LastName, profile.Email.Address,
            profile.Address.Street, profile.Address.City, profile.Address.State, profile.Address.ZipCode,profile.CompanyName
            );
    }
}