using System.Net.Mime;
using EasyInventory_Backend.IAM.Domain.Services;
using EasyInventory_Backend.IAM.Interfaces.REST.Resources;
using EasyInventory_Backend.IAM.Interfaces.REST.Transform;
using EasyInventory_Backend.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace EasyInventory_Backend.IAM.Interfaces.REST;


[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
[Produces((MediaTypeNames.Application.Json))]
public class AuthenticationController : ControllerBase
{
    private readonly IUsercommandService _userCommandService;

    public AuthenticationController(IUsercommandService userCommandService)
    {
        _userCommandService = userCommandService;
    }

    [AllowAnonymous]
    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp([FromBody] SignUpResource signUpResource)
    {
        var signUpCommand = SIgnUpCommandFromResourceAssembler.ToCommandFromResource(signUpResource);
        await _userCommandService.Handle(signUpCommand);
        return Ok("User created successfully");
    }

    [AllowAnonymous]
    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn([FromBody] SignInResource signInResource)
    {
        var signInCommand = SignInCommandFromResourceAssembler.ToCommandFromResource(signInResource);
        var authenticatedUser = await _userCommandService.Handle(signInCommand);

        var resource =
            AuthenticatedUserResourceFromEntityAssembler.ToResourceFromEntity(authenticatedUser.user,
                authenticatedUser.token);
        return Ok(resource);
    }

}