using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace SecureApi.Controllers;

[ApiController]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
public class TaggedController : ControllerBase
{
    private readonly ILogger<TaggedController> _logger;
    public TaggedController(ILogger<TaggedController> logger)
    {
        _logger = logger;
    }

    [HttpGet()]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [Route("[controller]/")]
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

    [HttpGet("[controller]/All")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult GetAll()
    {
        _logger.LogInformation("Get Tagged");
        var found = User
            .Claims
            .Select( c => $"{c.Type}:{c.Value}")
            .ToList();

        if (!found.Any())
        {
            return NotFound();
        }

        return Ok(found);
    }
}