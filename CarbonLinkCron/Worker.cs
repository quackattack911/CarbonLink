using CarbonLinkServer.Service.Database;
using CarbonLinkServer.Service.Tesla;
using CarbonLinkServer.Service.WattTime;

namespace CarbonLinkCron
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly DatabaseService _databaseService;

        public Worker(ILogger<Worker> logger,
            DatabaseService databaseService)
        {
            _logger = logger;
            _databaseService = databaseService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var users = _databaseService.GetChargingUsers();
                foreach (var user in users)
                {
                    _logger.LogInformation("This user is charging: {user}", user.Id);
                }
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}