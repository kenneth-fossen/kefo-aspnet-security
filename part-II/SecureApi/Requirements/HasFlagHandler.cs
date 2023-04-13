using Microsoft.AspNetCore.Authorization;

namespace SecureApi.Requirements;

public class HasFlagHandler : AuthorizationHandler<HasFlag>
{
    private readonly ILogger<HasFlagHandler> _logger;
    public HasFlagHandler(ILogger<HasFlagHandler> logger)
    {
        _logger = logger;
    }
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasFlag requirement)
    {
        _logger.LogInformation("Handling Flag");
        var scope = context
            .User
            .FindFirst(claim => claim.Type == "scope");

        if (scope is null)
        {
            _logger.LogError("Failed to find the correct scope");
            return Task.CompletedTask;
        }

        if (scope.Value == requirement.FlagName)
        {
            _logger.LogInformation("Success");
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}