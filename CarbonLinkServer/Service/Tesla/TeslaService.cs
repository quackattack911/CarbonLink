using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Http;
using System;

namespace CarbonLinkServer.Service.Tesla;

public class TeslaService
{
    private readonly IConfiguration Configuration;
    private readonly IHttpClientFactory _httpClientFactory;

    public TeslaService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
    {
        Configuration = configuration;
        _httpClientFactory = httpClientFactory;
    }

    var accessToken = Configuration["Tesla:AccessToken"];

    // public async Task<ChargeStateDto> GetChargeState()
    // {
        
    // }
}