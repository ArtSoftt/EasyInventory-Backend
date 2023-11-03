using EasyInventory_Backend.Inventory.Domain.Model.Aggregates;
using EasyInventory_Backend.Inventory.Domain.Model.Queries;
using EasyInventory_Backend.Inventory.Domain.Repositories;
using EasyInventory_Backend.Inventory.Domain.Services;

namespace EasyInventory_Backend.Inventory.Application.Internal.QueryServices;

public class CustomerQueryService : ICustomerQueryService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerQueryService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Customer?> Handle(GetCustomerByIdentifierQuery query)
    {
        return await _customerRepository.FindByIdAsync(query.Id);
    }
}