using CarbonLinkServer.Resource;
using CarbonLinkServer.Service.Database;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CarbonLinkServer.Controllers;

[ApiController]
[Route("api/[controller]")]
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
    public IActionResult Post([FromBody] User user)
    {
        try
        {
            DbUser userToAdd = new DbUser
            {
                Id = Guid.NewGuid().ToString(),
                WalletAddress = user.WalletAddress,
                ChargingInProgress = false,
                TeslaToken = user.TeslaToken,
                TeslaId = user.TeslaId,
                Balance = 0
            };
            _databaseService.Create(userToAdd);
            return StatusCode((int)HttpStatusCode.Created);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
