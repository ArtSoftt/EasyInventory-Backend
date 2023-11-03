using EasyInventory_Backend.Inventory.Domain.Model.Commands;
using EasyInventory_Backend.Inventory.Domain.Model.Queries;
using EasyInventory_Backend.Inventory.Domain.Services;
using EasyInventory_Backend.Inventory.Interfaces.REST.Resources;
using EasyInventory_Backend.Inventory.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EasyInventory_Backend.Inventory.Interfaces.REST;
[ApiController]
[Route("api/v1/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerQueryService _customerQueryService;
    private readonly ICustomerCommandService _customerCommandService;

    public CustomerController(ICustomerCommandService customerCommandService,
        ICustomerQueryService customerQueryService)
    {
        _customerCommandService = customerCommandService;
        _customerQueryService = customerQueryService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerResource createCustomerResource)
    {
        var createCustomerCommand =
            CreateCustomerCommandFromResourceAssembler.ToCommandFromResource(createCustomerResource);
        var customer = await _customerCommandService.Handle(createCustomerCommand);
        var resource = CustomerResourceFromEntityAssembler.ToResourceFromEntity(customer);
        return CreatedAtAction(nameof(GetCustomerById), new { id = resource.Id }, resource);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCustomerById(int id)
    {
        var getCustomerByIdQuery = new GetCustomerByIdentifierQuery(id);
        var customer = await _customerQueryService.Handle(getCustomerByIdQuery);
        var resource = CustomerResourceFromEntityAssembler.ToResourceFromEntity(customer);
        return Ok(resource);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCustomerById(int id)
    {
        var deleteCustomerCommand = new DeleteProductCommand(id);
        var newProduct = await _customerCommandService.Handle(deleteCustomerCommand);
        var resource = CustomerResourceFromEntityAssembler.ToResourceFromEntity(newProduct);
        return Ok(resource);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCustomer([FromBody] CreateCustomerResource createCustomerResource)
    {
        var updateCustomerCommand =
            UpdateCustomerCommandFromResourceAssembler.ToCommandFromResource(createCustomerResource);
        var customer = await _customerCommandService.Handle(updateCustomerCommand);
        var resource = CustomerResourceFromEntityAssembler.ToResourceFromEntity(customer);
        return Ok(resource);
    }
}