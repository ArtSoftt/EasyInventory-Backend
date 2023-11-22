using EasyInventory_Backend.IAM.Domain.Aggregates;
using EasyInventory_Backend.Shared.Domain.Repositories;

namespace EasyInventory_Backend.IAM.Domain.Repositories;

public interface IUserRepository: IBaseRepository<User>
{
    Task<User?> FindByUsernameAsync(string username);
    bool ExistsByUsername(string username);
}