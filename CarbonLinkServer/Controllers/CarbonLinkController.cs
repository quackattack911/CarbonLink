using CarbonLinkServer.Resource;
using CarbonLinkServer.Service.Database;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CarbonLinkServer.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CarbonLinkController : ControllerBase
{
    private readonly ILogger<CarbonLinkController> _logger;
    private readonly DatabaseService _databaseService;

    public CarbonLinkController(ILogger<CarbonLinkController> logger, DatabaseService databaseService)
    {
        _logger = logger;
        _databaseService = databaseService;
    }

    [HttpPost(Name = "AddUser")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult AddUser([FromBody] User user)
    {
        try
        {
            DbUser userToAdd = new DbUser
            {
                WalletAddress = user.WalletAddress,
                TeslaToken = user.TeslaToken,
                TeslaId = user.TeslaId,
            };
            _databaseService.Create(userToAdd);
            return StatusCode((int)HttpStatusCode.Created);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest();
        }
    }

    [HttpPost(Name = "StartCharging")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult StartCharging([FromBody] Wallet wallet)
    {
        try
        {

        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest();
        }
    }
}
