using EasyInventory_Backend.Inventory.Domain.Model.Commands;
using EasyInventory_Backend.Inventory.Domain.Model.Queries;
using EasyInventory_Backend.Inventory.Domain.Services;
using EasyInventory_Backend.Inventory.Interfaces.REST.Resources;
using EasyInventory_Backend.Inventory.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace EasyInventory_Backend.Inventory.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class SalesController :ControllerBase
{
    private readonly ISaleCommandService _saleCommandService;
    private readonly ISaleQueryService _saleQueryService;

    public SalesController(ISaleCommandService saleCommandService, ISaleQueryService saleQueryService)
    {
        _saleCommandService = saleCommandService;
        _saleQueryService = saleQueryService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSale([FromBody] CreateSaleResource saleResource)
    {
        var createSaleCommand = CreateSaleCommandFromResourceAssembler.ToCommandFromResource(saleResource);
        var sale = await _saleCommandService.Handle(createSaleCommand);
        var resource = SaleResourceFromEntityAssembler.ToResourceFromEntity(sale);
        return CreatedAtAction(nameof(GetSaleByIdentifier), new { id = resource.Id }, resource);
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetSaleByIdentifier(int id)
    {
        var getSaleQuery = new GetSaleByIdentifierQuery(id);
        var sale = await _saleQueryService.Handle(getSaleQuery);
        var resource = SaleResourceFromEntityAssembler.ToResourceFromEntity(sale);
        return Ok(resource);

    }
    
    [HttpDelete("{name}")]
    public async Task<IActionResult> DeleteSaleByName([FromRoute]string name)
    {
        var deleteSaleCommand = new DeleteSaleCommand(name);
        var sale = await _saleCommandService.Handle(deleteSaleCommand);
        return Ok(sale);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSale([FromBody] CreateSaleResource sale)
    {
        var updateSaleCommand = UpdateSaleCommandFromResourceAssembler.ToCommandFromResource(sale);
        var newSale = await _saleCommandService.Handle(updateSaleCommand);
        var resource = SaleResourceFromEntityAssembler.ToResourceFromEntity(newSale);
        return Ok(resource);

    }
    
    
}