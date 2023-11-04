
using EasyInventory_Backend.Inventory.Domain.Model.Commands;
using EasyInventory_Backend.Inventory.Domain.Model.Queries;
using EasyInventory_Backend.Inventory.Domain.Services;
using EasyInventory_Backend.Inventory.Interfaces.REST.Resources;
using EasyInventory_Backend.Inventory.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace EasyInventory_Backend.Inventory.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductQueryService _productQueryService;
    private readonly IProductCommandService _productCommandService;

    public ProductsController(IProductQueryService productQueryService,IProductCommandService productCommandService)
    {
        _productQueryService = productQueryService;
        _productCommandService = productCommandService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductResource createProductResource)
    {
        var createProductCommand =
            CreateProductCommandFromResourceAssembler.ToCommandFromResource(createProductResource);
        var product = await _productCommandService.Handle(createProductCommand);
        var resource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
        return CreatedAtAction(nameof(GetProductByIdentifier), new { id = resource.Id }, resource);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetProductByIdentifier(int id)
    {
        var getProductByIdQuery = new GetProductByIdentifierQuery(id);
        var product = await _productQueryService.Handle(getProductByIdQuery);   
        var resource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
        return Ok(resource);
    }

    [HttpGet("products{id:int}")]
    public async Task<IActionResult> GetProductsByUserId(int id)
    {
        var getProductsByUserIdQuery = new GetProductsByUserIdQuery(id);
        var products = await _productQueryService.Handle(getProductsByUserIdQuery);
        var resources = products.Select(ProductResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProductByName( [FromBody]CreateProductResource product)
    {
        var updateProductByIdCommand = UpdateProductCommandFromResourceAssembler.ToCommandFromResource(product);
        var newProduct = await _productCommandService.Handle(updateProductByIdCommand);
        var resource = ProductResourceFromEntityAssembler.ToResourceFromEntity(newProduct);
        return Ok(resource);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProductById(int id)
    {
        var deleteProductCommand = new DeleteProductCommand(id);
        var product = await _productCommandService.Handle(deleteProductCommand);
        return Ok(product);
    }
    
}