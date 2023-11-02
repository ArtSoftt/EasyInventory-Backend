using EasyInventory_Backend.Inventory.Domain.Model.Aggregates;
using EasyInventory_Backend.Inventory.Domain.Model.Commands;
using EasyInventory_Backend.Inventory.Domain.Repositories;
using EasyInventory_Backend.Inventory.Domain.Services;
using EasyInventory_Backend.Shared.Domain.Repositories;

namespace EasyInventory_Backend.Inventory.Application.Internal.CommandServices;

public class CustomerCommandService : ICustomerCommandService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CustomerCommandService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Customer> Handle(CreateCustomerCommand command)
    {
        var customer = new Customer(command.Name, command.LastName, command.Birthday, command.Email, command.Phone);
        await _customerRepository.AddAsync(customer);
        await _unitOfWork.CompleteAsync();
        return customer;
    }


    public async Task<Customer> Handle(UpdateCustomerCommand command)
    {
        var existingCustomer = await _customerRepository.FindByNameAsync(command.Name);
        if (existingCustomer is null)
            throw new Exception("Customer not found");
        if (command.Name != null)
            existingCustomer.Name = command.Name;
        if (command.LastName != null)
            existingCustomer.LastName = command.LastName;
        if (command.Birthday != null)
            existingCustomer.Birthday = command.Birthday;
        if (command.Email != null)
            existingCustomer.Email = command.Email;
        if (command.Phone != null)
            existingCustomer.Phone = command.Phone;
        _customerRepository.Update(existingCustomer);
        await _unitOfWork.CompleteAsync();
        return existingCustomer;

    }

    public async Task<Customer> Handle(DeleteProductCommand command)
    {
        var existingCustomer = await _customerRepository.FindByIdAsync(command.Id);
        if (existingCustomer is null)
            throw new Exception("Customer not found");
        _customerRepository.Remove(existingCustomer);
        await _unitOfWork.CompleteAsync();
        return existingCustomer;
    }
}