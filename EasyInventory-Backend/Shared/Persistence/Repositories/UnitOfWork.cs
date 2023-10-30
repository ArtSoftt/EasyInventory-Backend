using EasyInventory_Backend.Shared.Persistence.Contexts;
using EasyInventory_Backend.Shared.Domain.Repositories;

namespace EasyInventory_Backend.Shared.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}