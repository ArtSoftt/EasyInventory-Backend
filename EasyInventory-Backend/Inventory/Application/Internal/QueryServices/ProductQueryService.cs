using EasyInventory_Backend.Inventory.Domain.Model.Aggregates;
using EasyInventory_Backend.Inventory.Domain.Model.Queries;
using EasyInventory_Backend.Inventory.Domain.Repositories;
using EasyInventory_Backend.Inventory.Domain.Services;

namespace EasyInventory_Backend.Inventory.Application.Internal.QueryServices;

public class ProductQueryService : IProductQueryService
{
    private readonly IProductRepository _productRepository;

    public ProductQueryService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product?> Handle(GetProductByIdentifierQuery query)
    {
        return await _productRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Product>> Handle(GetProductsByUserIdQuery query)
    {
        return await _productRepository.FindByUserIdAsync(query.Id);
    }
}