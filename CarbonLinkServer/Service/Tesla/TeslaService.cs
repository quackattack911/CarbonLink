namespace CarbonLinkServer.Service.Tesla;

public class TeslaService
{
    private readonly IConfiguration _configuration;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _accessToken;

    public TeslaService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
    {
        _configuration = configuration;
        _httpClientFactory = httpClientFactory;
        _accessToken = _configuration["Tesla:AccessToken"];
    }

    public async Task<ChargeStateDto> GetChargeState()
    {
        var httpClient = _httpClientFactory.CreateClient("Tesla");
    }
}