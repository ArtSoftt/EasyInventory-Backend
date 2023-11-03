using EasyInventory_Backend.Inventory.Domain.Model.Aggregates;
using EasyInventory_Backend.Inventory.Domain.Model.Commands;

namespace EasyInventory_Backend.Inventory.Domain.Services;

public interface ICustomerCommandService
{
    Task<Customer> Handle(CreateCustomerCommand command);
    Task<Customer> Handle(UpdateCustomerCommand command);
    Task<Customer> Handle(DeleteProductCommand command);
}