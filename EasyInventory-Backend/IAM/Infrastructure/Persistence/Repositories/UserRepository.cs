using EasyInventory_Backend.IAM.Domain.Aggregates;
using EasyInventory_Backend.IAM.Domain.Repositories;
using EasyInventory_Backend.Shared.Infrastructure.Persistence.Configuration;
using EasyInventory_Backend.Shared.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EasyInventory_Backend.IAM.Infrastructure.Persistence.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<User?> FindByUsernameAsync(string username)
    {
        return await Context.Set<User>()
            .Include(p=>p.Profile)
            .FirstOrDefaultAsync(p => p.Username == username);
    }

    public bool ExistsByUsername(string username)
    {
        return Context.Set<User>()
            .Include(p=>p.Profile)
            .Any(user => user.Username.Equals(username));
    }
}