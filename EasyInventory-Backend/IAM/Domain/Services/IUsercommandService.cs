using EasyInventory_Backend.IAM.Domain.Aggregates;
using EasyInventory_Backend.IAM.Domain.Commands;

namespace EasyInventory_Backend.IAM.Domain.Services;

public interface IUsercommandService
{
    
    Task Handle(SignUpCommand command);
    Task<(User user, string token)> Handle(SignInCommand command);
}