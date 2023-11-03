using EasyInventory_Backend.Inventory.Domain.Model.Aggregates;
using EasyInventory_Backend.Inventory.Domain.Model.Queries;
using EasyInventory_Backend.Inventory.Domain.Repositories;
using EasyInventory_Backend.Inventory.Domain.Services;
using EasyInventory_Backend.Shared.Domain.Repositories;

namespace EasyInventory_Backend.Inventory.Application.Internal.QueryServices;

public class SaleQueryService :ISaleQueryService
{
    private readonly ISaleRepository _saleRepository;

    public SaleQueryService(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }
    public async Task<Sale?> Handle(GetSaleByIdentifierQuery query)
    {
        return await _saleRepository.FindByIdAsync(query.Id);
    }
}