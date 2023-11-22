using EasyInventory_Backend.IAM.Application.Internal.OutboundServices;
using EasyInventory_Backend.IAM.Domain.Aggregates;
using EasyInventory_Backend.IAM.Domain.Commands;
using EasyInventory_Backend.IAM.Domain.Repositories;
using EasyInventory_Backend.IAM.Domain.Services;
using EasyInventory_Backend.Shared.Domain.Repositories;

namespace EasyInventory_Backend.IAM.Application.Internal.CommandServices;

public class UserCommandService : IUsercommandService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHashingService _hashingService;
    private readonly ITokenService _tokenService;

    public UserCommandService(IUserRepository userRepository, IUnitOfWork unitOfWork, IHashingService hashingService, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _hashingService = hashingService;
        _tokenService = tokenService;
    }

    public async Task Handle(SignUpCommand command)
    {
        if (_userRepository.ExistsByUsername(command.Username))
            throw new Exception($"Username {command.Username} is already taken");
        var hashedPassword = _hashingService.HashPassword(command.Password);
        var user = new User(command.Username, hashedPassword,command.ProfileId);
        try
        {
            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"Error while creating user: {e.Message}");
        }
    }

    public async Task<(User user, string token)> Handle(SignInCommand command)
    {
        var user = await _userRepository.FindByUsernameAsync(command.Username);

        if (user == null || !_hashingService.VerifyPassword(command.Password, user.PasswordHash))
            throw new Exception("Invalid username or password");

        var token = _tokenService.GenerateToken(user);
        return (user, token);
    }
}