using EasyInventory_Backend.IAM.Application.Internal.OutboundServices;
using BCryptNet = BCrypt.Net.BCrypt;
namespace EasyInventory_Backend.IAM.Infrastructure.Hashing.Services;

public class HashingService:IHashingService
{
    public string HashPassword(string password)
    {
        return BCryptNet.HashPassword(password);
    }

    public bool VerifyPassword(string password, string passwordHash)
    {
        return BCryptNet.Verify(password, passwordHash);
    }
}