using CarbonLinkCron;
using CarbonLinkServer.Service.Database;
using CarbonLinkServer.Service.Tesla;
using CarbonLinkServer.Service.WattTime;
using Microsoft.Net.Http.Headers;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        string userAgent = "CarbonLinkCron/0.0.1";
        services.AddHttpClient("Tesla", httpClient =>
        {
            httpClient.BaseAddress = new Uri("https://owner-api.teslamotors.com/");
            httpClient.DefaultRequestHeaders.Add(
                HeaderNames.UserAgent, userAgent);
        });

        services.AddHttpClient("WattTime", httpClient =>
        {
            httpClient.BaseAddress = new Uri("https://api2.watttime.org/v2/");
            httpClient.DefaultRequestHeaders.Add(
                HeaderNames.UserAgent, userAgent);
        });
        services.AddHostedService<Worker>();
        services.AddSingleton<TeslaService>();
        services.AddSingleton<WattTimeService>();
        services.AddSingleton<DatabaseService>();
    })
    .Build();

await host.RunAsync();
