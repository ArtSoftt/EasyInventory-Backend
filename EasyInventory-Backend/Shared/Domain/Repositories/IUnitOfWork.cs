namespace EasyInventory_Backend.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}