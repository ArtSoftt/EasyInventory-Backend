using EasyInventory_Backend.IAM.Domain.Aggregates;

namespace EasyInventory_Backend.IAM.Application.Internal.OutboundServices;

public interface ITokenService
{
    string GenerateToken(User user);
    int? ValidateToken(string token);

}