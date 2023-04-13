using Microsoft.AspNetCore.Authorization;

namespace SecureApi.Requirements;

public class HasFlagHandler : AuthorizationHandler<HasFlag>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasFlag requirement)
    {
        if (false)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}