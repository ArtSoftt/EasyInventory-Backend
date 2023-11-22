using EasyInventory_Backend.IAM.Domain.Aggregates;
using EasyInventory_Backend.Profiles.Domain.Model.Aggregates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EasyInventory_Backend.IAM.Infrastructure.Pipeline.Middleware.Attributes;

[AttributeUsage(AttributeTargets.Class|AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
        if (allowAnonymous)
        {
            Console.WriteLine("Skipping authorization");
            return;
        }

        var user = (User?)context.HttpContext.Items["User"];
        if (user == null) context.Result = new UnauthorizedResult();
    }
}