using EasyInventory_Backend.Inventory.Domain.Model.Aggregates;
using EasyInventory_Backend.Inventory.Domain.Model.Commands;
using EasyInventory_Backend.Inventory.Domain.Repositories;
using EasyInventory_Backend.Inventory.Domain.Services;
using EasyInventory_Backend.Shared.Domain.Repositories;

namespace EasyInventory_Backend.Inventory.Application.Internal.CommandServices;

public class SaleCommandService : ISaleCommandService
{
    private readonly ISaleRepository _saleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SaleCommandService(ISaleRepository saleRepository, IUnitOfWork unitOfWork)
    {
        _saleRepository = saleRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Sale> Handle(CreateSaleCommand command)
    {
        var sale = new Sale(command.Name, command.SaleDate,command.TotalCost);
        await _saleRepository.AddAsync(sale);
        await _unitOfWork.CompleteAsync();
        return sale;
    }

    public async Task<Sale> Handle(DeleteSaleCommand command)
    {
        var sale = await _saleRepository.FindByNameAsync(command.Name);
        if (sale is null)
            throw new Exception("Sale not found");
        
        _saleRepository.Remove(sale);
        await _unitOfWork.CompleteAsync();
        return sale;

    }

    public async Task<Sale> Handle(UpdateSaleCommand command)
    {
        var sale = await _saleRepository.FindByNameAsync(command.Name);
        if (sale is null)
            throw new Exception("Sale not Found");
        if (command.SaleDate is not null)
            sale.SaleDate = command.SaleDate;
        if (command.TotalCost != null)
            sale.TotalCost = command.TotalCost;
        _saleRepository.Update(sale);
        await _unitOfWork.CompleteAsync();
        return sale;


    }
}