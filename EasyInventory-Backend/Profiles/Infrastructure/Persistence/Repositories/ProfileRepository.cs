
using EasyInventory_Backend.Profiles.Domain.Model.Aggregates;
using EasyInventory_Backend.Profiles.Domain.Repositories;
using EasyInventory_Backend.Shared.Infrastructure.Persistence.Configuration;
using EasyInventory_Backend.Shared.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EasyInventory_Backend.Profiles.Infrastructure.Persistence.Repositories;

public class ProfileRepository : BaseRepository<Profile>,IProfileRepository
{
    public ProfileRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<bool> FindByEmail(string email)
    {
        bool profileExists = await Context.Set<Profile>()
            .AnyAsync(p => p.Email.Address == email);
        return profileExists;
    }

    public new async  Task<Profile?> FindByIdAsync(int id)
    {
        return await Context.Set<Profile>()
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.Id == id);

    }
}