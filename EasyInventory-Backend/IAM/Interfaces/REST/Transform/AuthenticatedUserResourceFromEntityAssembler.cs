using EasyInventory_Backend.IAM.Domain.Aggregates;
using EasyInventory_Backend.IAM.Interfaces.REST.Resources;

namespace EasyInventory_Backend.IAM.Interfaces.REST.Transform;

public static class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticateUserResource ToResourceFromEntity(User user, string token)
    {
        return new AuthenticateUserResource(user.Id, user.Username, token,user.ProfileId);
    }
}