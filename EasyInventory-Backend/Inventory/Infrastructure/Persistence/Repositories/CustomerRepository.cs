using EasyInventory_Backend.Inventory.Domain.Model.Aggregates;
using EasyInventory_Backend.Inventory.Domain.Repositories;
using EasyInventory_Backend.Shared.Infrastructure.Persistence.Configuration;
using EasyInventory_Backend.Shared.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EasyInventory_Backend.Inventory.Infrastructure.Persistence.Repositories;

public class CustomerRepository:BaseRepository<Customer>,ICustomerRepository
{
    private readonly ICustomerRepository _customerRepository;
    public CustomerRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Customer?> FindByNameAsync(string name)
    {
        return await Context.Set<Customer>()
            .FirstOrDefaultAsync(p => p.Name == name);
    }
}