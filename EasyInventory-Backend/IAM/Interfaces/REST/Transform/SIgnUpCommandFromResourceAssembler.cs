using EasyInventory_Backend.IAM.Domain.Commands;
using EasyInventory_Backend.IAM.Interfaces.REST.Resources;

namespace EasyInventory_Backend.IAM.Interfaces.REST.Transform;

public static  class SIgnUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Username, resource.Password,resource.ProfileId);
    }
    
}