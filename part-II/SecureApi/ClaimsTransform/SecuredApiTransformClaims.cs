using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace SecureApi.ClaimsTransform;

public class SecuredApiTransformClaims : IClaimsTransformation
{

    public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        var id = (ClaimsIdentity)principal.Identity;
        if (id is null) return Task.FromResult(principal);

        id.AddClaim(new Claim("tagged", "secured"));

        return Task.FromResult(new ClaimsPrincipal(id));
    }
}