using EasyInventory_Backend.Profiles.Domain.Model.Aggregates;
using EasyInventory_Backend.Profiles.Domain.Model.Commands;
using EasyInventory_Backend.Profiles.Domain.Repositories;
using EasyInventory_Backend.Profiles.Domain.Services;
using EasyInventory_Backend.Shared.Domain.Repositories;

namespace EasyInventory_Backend.Profiles.Application.Internal.CommandServices;

public class ProfileCommandService : IProfileCommandService
{
    private readonly IProfileRepository _profileRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProfileCommandService(IProfileRepository profileRepository, IUnitOfWork unitOfWork)
    {
        _profileRepository = profileRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Profile?> Handle(CreateProfileCommand createProfileCommand)
    {
        var profile = new Profile(createProfileCommand.FirstName, createProfileCommand.LastName,
            createProfileCommand.Email, createProfileCommand.Street, createProfileCommand.City,
            createProfileCommand.State, createProfileCommand.ZipCode,createProfileCommand.CompanyName);
        if (_profileRepository.FindByEmail(createProfileCommand.Email).Result)
            throw new Exception("Profile already exist with the same email");
        await _profileRepository.AddAsync(profile);
        await _unitOfWork.CompleteAsync();
        return profile;
    }
}