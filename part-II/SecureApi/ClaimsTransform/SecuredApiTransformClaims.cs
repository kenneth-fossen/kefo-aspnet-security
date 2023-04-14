#nullable disable
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;

namespace SecureApi.ClaimsTransform;

public class SecuredApiTransformClaims : IClaimsTransformation
{

    private readonly ILogger<SecuredApiTransformClaims> _logger;
    public SecuredApiTransformClaims(ILogger<SecuredApiTransformClaims> logger)
    {
        _logger = logger;
    }
    public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        var id = (ClaimsIdentity)principal.Identity;
        if (id is null) return Task.FromResult(principal);

        WriteClaimsToConsole(id.Claims);

        id.AddClaim(new Claim("tagged", "secured"));

        return Task.FromResult(new ClaimsPrincipal(id));
    }

    private void WriteClaimsToConsole(IEnumerable<Claim> userClaims)
    {
        var claims = new StringBuilder();
        claims.Append("== Start List of Claims ==");
        foreach (var claim in userClaims)
        {
            claims.Append($"{claim.Type}:{claim.Value}\n");
        }

        claims.Append("== End List of Claims ==");

        _logger.LogInformation(claims.ToString());
    }
}