using Microsoft.AspNetCore.Mvc;

namespace SecureApi.Controllers;

[ApiController]
[Route("[controller]")]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
public class TaggedController : ControllerBase
{
    private readonly ILogger<TaggedController> _logger;
    public TaggedController(ILogger<TaggedController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult Get()
    {
        _logger.LogInformation("Get Tagged");
        var found = User
            .Claims
            .FirstOrDefault(claim => claim.Type == "tagged");

        if (found is null)
        {
            return NotFound();
        }

        return Ok($"tagged: {found.Value}");
    }
}