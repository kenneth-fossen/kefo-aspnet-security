using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecureApi.Controllers;

[ApiController]
[Route("[controller]")]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
public class FlagController: ControllerBase
{
    private readonly ILogger<FlagController> _logger;

    public FlagController(ILogger<FlagController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Authorize(Policy = "HasFlagScope")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult GetFlag()
    {
        _logger.LogInformation("Get Flag");

        return Ok(Environment.GetEnvironmentVariable(SecureApiConstants.FlagName));
    }
}