
using EasyInventory_Backend.Profiles.Domain.Model.Aggregates;
using EasyInventory_Backend.Shared.Domain.Repositories;

namespace EasyInventory_Backend.Profiles.Domain.Repositories;

public interface IProfileRepository : IBaseRepository<Profile>
{
    Task<bool> FindByEmail(string email);
}