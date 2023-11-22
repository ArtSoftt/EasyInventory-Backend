using System.Net.Mime;
using EasyInventory_Backend.IAM.Domain.Queries;
using EasyInventory_Backend.IAM.Domain.Services;
using EasyInventory_Backend.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using EasyInventory_Backend.IAM.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace EasyInventory_Backend.IAM.Interfaces.REST;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class UsersController :ControllerBase
{
    private readonly IUserQueryService _userQueryService;

    public UsersController(IUserQueryService userQueryService)
    {
        _userQueryService = userQueryService;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var getUserByIdQuery = new GetUserByIdQuery(id);
        var user = await _userQueryService.Handle(getUserByIdQuery);
        var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return Ok(userResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUser()
    {
        var getAllUsersQuery = new GetAllUsersQuery();
        var users = await _userQueryService.Handle(getAllUsersQuery);
        var userResources = users.Select(UserResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(userResources);
    }
}