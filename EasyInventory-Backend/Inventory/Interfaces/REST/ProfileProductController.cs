using EasyInventory_Backend.Inventory.Domain.Model.Queries;
using EasyInventory_Backend.Inventory.Domain.Services;
using EasyInventory_Backend.Inventory.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace EasyInventory_Backend.Inventory.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class ProfileProductController : ControllerBase
{
    private readonly IProductQueryService _productQueryService;

    public ProfileProductController(IProductQueryService productQueryService)
    {
        _productQueryService = productQueryService;
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetProductsByUserId(int id)
    {
        var getProductsByUserIdQuery = new GetProductsByUserIdQuery(id);
        var products = await _productQueryService.Handle(getProductsByUserIdQuery);
        var resources = products.Select(ProductResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}