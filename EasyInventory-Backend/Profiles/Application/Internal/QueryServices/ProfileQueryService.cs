using EasyInventory_Backend.Profiles.Domain.Model.Aggregates;
using EasyInventory_Backend.Profiles.Domain.Model.Queries;
using EasyInventory_Backend.Profiles.Domain.Repositories;
using EasyInventory_Backend.Profiles.Domain.Services;

namespace EasyInventory_Backend.Profiles.Application.Internal.QueryServices;

public class ProfileQueryService : IProfileQueryService
{
    private readonly IProfileRepository _profileRepository;

    public ProfileQueryService(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }

    public async Task<Profile> Handle(GetProfileByIdQuery profileByIdQuery)
    {
        return await _profileRepository
            .FindByIdAsync(profileByIdQuery.Id) ?? throw new InvalidOperationException();
    }
}