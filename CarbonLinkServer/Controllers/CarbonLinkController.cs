using CarbonLinkServer.Resource;
using CarbonLinkServer.Service.Database;
using CarbonLinkServer.Service.Tesla;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CarbonLinkServer.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CarbonLinkController : ControllerBase
{
    private readonly ILogger<CarbonLinkController> _logger;
    private readonly DatabaseService _databaseService;
    private readonly TeslaService _teslaService;

    public CarbonLinkController(ILogger<CarbonLinkController> logger,
        DatabaseService databaseService,
        TeslaService teslaService)
    {
        _logger = logger;
        _databaseService = databaseService;
        _teslaService = teslaService;
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
            _databaseService.CreateUser(userToAdd);
            return StatusCode((int)HttpStatusCode.Created);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest();
        }
    }

    [HttpPost(Name = "WakeCar")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> WakeCar([FromBody] Wallet wallet)
    {
        try
        {
            DbUser user = _databaseService.GetUserFromWallet(wallet.WalletAddress);
            await _teslaService.WakeVehicle(user.TeslaToken, user.TeslaId);
            return StatusCode((int)HttpStatusCode.OK);
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
    public async Task<IActionResult> StartChargingAsync([FromBody] Wallet wallet)
    {
        try
        {
            DbUser user = _databaseService.GetUserFromWallet(wallet.WalletAddress);
            var driveState = await _teslaService.GetDriveState(user.TeslaToken, user.TeslaId);
            _databaseService.UpdateCoordinates(user.Id, (double)driveState.Latitude, (double)driveState.Longitude);
            _databaseService.StartCharging(user.Id);
            return StatusCode((int)HttpStatusCode.OK);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest();
        }
    }

    [HttpPost(Name = "StopCharging")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> StopChargingAsync([FromBody] Wallet wallet)
    {
        try
        {
            DbUser user = _databaseService.GetUserFromWallet(wallet.WalletAddress);
            _databaseService.StopCharging(user.Id);
            return StatusCode((int)HttpStatusCode.OK);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest();
        }
    }
}
