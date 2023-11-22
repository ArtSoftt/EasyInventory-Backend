using EasyInventory_Backend.IAM.Domain.Commands;
using EasyInventory_Backend.IAM.Interfaces.REST.Resources;

namespace EasyInventory_Backend.IAM.Interfaces.REST.Transform;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Username, resource.Password);
    }
}