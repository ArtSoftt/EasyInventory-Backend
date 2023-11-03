using EasyInventory_Backend.Inventory.Domain.Model.Commands;
using EasyInventory_Backend.Inventory.Domain.Model.Queries;
using EasyInventory_Backend.Inventory.Domain.Services;
using EasyInventory_Backend.Inventory.Interfaces.REST.Resources;
using EasyInventory_Backend.Inventory.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace EasyInventory_Backend.Inventory.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class ProviderController :ControllerBase
{
    private readonly IProviderQueryService _providerQueryService;
    private readonly IProviderCommandService _providerCommandService;

    public ProviderController(IProviderCommandService providerCommandService,
        IProviderQueryService providerQueryService)
    {
        _providerQueryService = providerQueryService;
        _providerCommandService = providerCommandService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProvider([FromBody] CreateProviderResource createProviderResource)
    {
        var createProviderCommand =
            CreateProviderCommandFromResourceAssembler.ToCommandFromResource(createProviderResource);
        var provider = await _providerCommandService.Handle(createProviderCommand);
        var resource = ProviderResourceFromEntityAssembler.ToResourceFromEntity(provider);
        return CreatedAtAction(nameof(GetProviderByIdentifier), new { id = resource.Id },resource);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetProviderByIdentifier(int id)
    {
        var getProviderByIdQuery = new GetProviderByIdQuery(id);
        var provider = await _providerQueryService.Handle(getProviderByIdQuery);
        var resource = ProviderResourceFromEntityAssembler.ToResourceFromEntity(provider);
        return Ok(resource);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProviderByName([FromBody] CreateProviderResource provider)
    {
        var updateProviderByNameCommand = UpdateProviderCommandFromResourceAssembler.ToCommandFromResource(provider);
        var newProvider = await _providerCommandService.Handle(updateProviderByNameCommand);
        var resource = ProviderResourceFromEntityAssembler.ToResourceFromEntity(newProvider);
        return Ok(resource);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProviderById(int id)
    {
        var deleteProviderCommand = new DeleteProviderCommand(id);
        var provider = await _providerCommandService.Handle(deleteProviderCommand);
        return Ok(provider);
    }


}