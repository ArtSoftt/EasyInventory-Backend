using EasyInventory_Backend.IAM.Domain.Aggregates;
using EasyInventory_Backend.IAM.Interfaces.REST.Resources;

namespace EasyInventory_Backend.IAM.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User user)
    {
        return new UserResource(user.Id, user.Username,user.ProfileId);
    }
}