using EasyInventory_Backend.Profiles.Domain.Model.Aggregates;
using EasyInventory_Backend.Profiles.Domain.Model.Queries;

namespace EasyInventory_Backend.Profiles.Domain.Services;

public interface IProfileQueryService
{
    Task<Profile> Handle(GetProfileByIdQuery profileByIdQuery);
}