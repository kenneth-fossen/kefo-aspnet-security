using Microsoft.AspNetCore.Authorization;

namespace SecureApi.Requirements;

public class HasFlag : IAuthorizationRequirement
{
    public HasFlag(string flagName) => FlagName = flagName;

    public string FlagName { get; }
}