using CarbonLinkServer.Service.Database;
using CarbonLinkServer.Service.Tesla;
using CarbonLinkServer.Service.WattTime;

namespace CarbonLinkCron
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly DatabaseService _databaseService;
        private readonly TeslaService _teslaService;
        private readonly WattTimeService _wattTimeService;

        public Worker(ILogger<Worker> logger,
            DatabaseService databaseService,
            TeslaService teslaService,
            WattTimeService wattTimeService)
        {
            _logger = logger;
            _databaseService = databaseService;
            _teslaService = teslaService;
            _wattTimeService = wattTimeService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var users = _databaseService.GetChargingUsers();
                foreach (var user in users)
                {
                    _logger.LogInformation("This user is charging: {user}", user.Id);
                    var chargeState = await _teslaService.GetChargeState(user.TeslaToken, user.TeslaId);
                    var wattTimeIndex = await _wattTimeService.GetRealTimeEmissions(user.Latitude, user.Longitude);
                    _logger.LogInformation("the index is {index}", wattTimeIndex.Percent);
                    var chargeDiff = chargeState.ChargeEnergyAdded - user.ChargeAdded;
                    var tokensGained = chargeDiff * (100 - wattTimeIndex.Percent);
                    _logger.LogInformation("This user gained {tokens} more tokens", tokensGained);
                    _databaseService.UpdateBalance(user.Id, (double)tokensGained);
                    _databaseService.UpdateChargeState(user.Id, (double)chargeState.ChargeEnergyAdded);
                }
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(60000, stoppingToken);
            }
        }
    }
}