using EasyInventory_Backend.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using EasyInventory_Backend.Profiles.Domain.Model.Queries;
using EasyInventory_Backend.Profiles.Domain.Services;
using EasyInventory_Backend.Profiles.Interfaces.REST.Resources;
using EasyInventory_Backend.Profiles.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace EasyInventory_Backend.Profiles.Interfaces;
[ApiController]
[Route("api/v1/[controller]")]
public class ProfilesController: ControllerBase
{
    private readonly IProfileCommandService _profileCommandService;
    private readonly IProfileQueryService _profileQueryService;


    public ProfilesController(IProfileCommandService profileCommandService, IProfileQueryService profileQueryService)
    {
        _profileCommandService = profileCommandService;
        _profileQueryService = profileQueryService;
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> CreateProfile([FromBody] CreateProfileResource createProfileResource)
    {
        var createProfileCommand =
            CreateProfileCommandFromResourceAssembler.ToCommandFromResource(createProfileResource);
        var profile = await _profileCommandService.Handle(createProfileCommand);
        if (profile is null) throw new Exception("A problem occurred when profile is creating");
        var resource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(profile);
        return CreatedAtAction(nameof(GetProfileById), new { id = resource.Id }, resource);

    }
    [HttpGet("{id:int}")]
    
    public async Task<IActionResult> GetProfileById(int id)
    {
        var getProfileByIdQuery = new GetProfileByIdQuery(id);
        var profile = await _profileQueryService.Handle(getProfileByIdQuery);
        var resource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(profile);
        return Ok(resource);
    }
}