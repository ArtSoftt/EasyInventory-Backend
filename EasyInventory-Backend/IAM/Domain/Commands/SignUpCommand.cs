namespace EasyInventory_Backend.IAM.Domain.Commands;

public record SignUpCommand(string Username,string Password,int ProfileId);