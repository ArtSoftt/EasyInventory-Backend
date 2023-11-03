using EasyInventory_Backend.Inventory.Domain.Model.Aggregates;
using EasyInventory_Backend.Inventory.Domain.Model.Commands;
using EasyInventory_Backend.Inventory.Domain.Repositories;
using EasyInventory_Backend.Inventory.Domain.Services;
using EasyInventory_Backend.Shared.Domain.Repositories;

namespace EasyInventory_Backend.Inventory.Application.Internal.CommandServices;

public class ProviderCommandService:IProviderCommandService
{
    private readonly IProviderRepository _providerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProviderCommandService(IProviderRepository providerRepository, IUnitOfWork unitOfWork)
    {
        _providerRepository = providerRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Provider> Handle(CreateProviderCommand command)
    {
        var provider = new Provider(command.Name, command.Phone, command.Ruc, command.Email);
        await _providerRepository.AddAsync(provider);
        await _unitOfWork.CompleteAsync();
        return provider;

    }

    public async Task<Provider> Handle(UpdateProviderCommand command)
    {
        var existingProvider = await _providerRepository.FindByNameAsync(command.Name);
        if (existingProvider is null)
            throw new Exception("Provider not found");
        if (command.Name != null)
            existingProvider.Name = command.Name;
        if (command.Email != null)
            existingProvider.Email = command.Email;
        if (command.Phone != null)
            existingProvider.Phone = command.Phone;
        if (command.Ruc != null)
            existingProvider.Ruc = command.Ruc;
        _providerRepository.Update(existingProvider);
        await _unitOfWork.CompleteAsync();
        return existingProvider;
    }

    public async Task<Provider> Handle(DeleteProviderCommand command)
    {
        var existingProvider = await _providerRepository.FindByIdAsync(command.Id);
        if (existingProvider is null)
            throw new Exception("Provider not found");
        _providerRepository.Remove(existingProvider);
        await _unitOfWork.CompleteAsync();
        return existingProvider;
    }
}