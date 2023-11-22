using EasyInventory_Backend.Profiles.Domain.Model.Aggregates;
using EasyInventory_Backend.Profiles.Domain.Model.Commands;

namespace EasyInventory_Backend.Profiles.Domain.Services;

public interface IProfileCommandService
{
    Task<Profile?> Handle(CreateProfileCommand createProfileCommand);
}