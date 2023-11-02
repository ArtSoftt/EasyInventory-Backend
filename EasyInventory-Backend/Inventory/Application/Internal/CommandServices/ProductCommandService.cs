using EasyInventory_Backend.Inventory.Domain.Model.Aggregates;
using EasyInventory_Backend.Inventory.Domain.Model.Commands;
using EasyInventory_Backend.Inventory.Domain.Repositories;
using EasyInventory_Backend.Inventory.Domain.Services;
using EasyInventory_Backend.Shared.Domain.Repositories;

namespace EasyInventory_Backend.Inventory.Application.Internal.CommandServices;

public class ProductCommandService: IProductCommandService
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductCommandService(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Product> Handle(CreateProductCommand command)
    {
        var product = new Product(command.Name, command.UnitPrice, command.RealPrice, command.Discount, command.Stock,
            command.CurrentStock, command.UserId);
        await _productRepository.AddAsync(product);
        await _unitOfWork.CompleteAsync();
        return product;
    }

    public async Task<Product> Handle(UpdateProductCommand command)
    {
        var existingProduct = await _productRepository.FindByNameAsync(command.Name);
        if (existingProduct == null)
            throw new Exception("Product not exist");
        if(command.Stock!=null)
            existingProduct.Stock = command.Stock;
        if(command.Discount!=null)
            existingProduct.Discount = command.Discount;
        if(command.Name!=null)
            existingProduct.Name = command.Name;
        if(command.RealPrice!=null)
            existingProduct.RealPrice = command.RealPrice;
        if(command.UnitPrice!=null)
            existingProduct.UnitPrice = command.UnitPrice;
        if(command.CurrentStock!=null)
            existingProduct.CurrentStock = command.CurrentStock;
        _productRepository.Update(existingProduct);
        await _unitOfWork.CompleteAsync();
        return existingProduct;
    }

    public async Task<Product> Handle(DeleteProductCommand command)
    {
        var existingProduct = await _productRepository.FindByIdAsync(command.Id);
        _productRepository.Remove(existingProduct);
        await _unitOfWork.CompleteAsync();
        return existingProduct;
    }
}