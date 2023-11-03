using EasyInventory_Backend.Inventory.Domain.Model.Aggregates;
using EasyInventory_Backend.Inventory.Domain.Model.Queries;
using EasyInventory_Backend.Inventory.Domain.Repositories;
using EasyInventory_Backend.Inventory.Domain.Services;

namespace EasyInventory_Backend.Inventory.Application.Internal.QueryServices;

public class ProviderQueryService : IProviderQueryService
{
    private readonly IProviderRepository _providerRepository;

    public ProviderQueryService(IProviderRepository providerRepository)
    {
        _providerRepository = providerRepository;
    }

    public async Task<Provider?> Handle(GetProviderByIdQuery query)
    {
        return await _providerRepository.FindByIdAsync(query.Id);
    }

}