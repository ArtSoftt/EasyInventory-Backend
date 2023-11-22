namespace EasyInventory_Backend.IAM.Interfaces.REST.Resources;

public record AuthenticateUserResource(int Id,string Username,string Token,int ProfileId);