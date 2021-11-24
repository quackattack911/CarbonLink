
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace CarbonLinkServer.Service.WattTime;

public class WattTimeService
{
    private readonly IConfiguration _configuration;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _username;
    private readonly string _password;

    public WattTimeService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
    {
        _configuration = configuration;
        _httpClientFactory = httpClientFactory;
        _username = _configuration["WattTime:Username"];
        _password = _configuration["WattTime:Password"];
    }

    public async Task<RealTimeEmissionsIndexDto> GetRealTimeEmissions()
    {
        string realTimeEmissionRoute = "index";
        var httpClient = _httpClientFactory.CreateClient("WattTime");
        var accessToken = await Login();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.Token);
        var httpResponseMessage = await httpClient.GetAsync(realTimeEmissionRoute);

        if (!httpResponseMessage.IsSuccessStatusCode && httpResponseMessage.Content == null)
        {
            throw new Exception("Get Real Time Emissions Failed!");
        }

        string responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
        var settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore
        };
        RealTimeEmissionsIndexDto realTimeEmissionsIndexDto = JsonConvert.DeserializeObject<RealTimeEmissionsIndexDto>(responseContent, settings);
        return realTimeEmissionsIndexDto;
    }

    private async Task<AccessTokenDto> Login()
    {
        string loginRoute = "login";
        var httpClient = _httpClientFactory.CreateClient("WattTime");
        //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
        var httpResponseMessage = await httpClient.GetAsync(loginRoute);
        if (!httpResponseMessage.IsSuccessStatusCode && httpResponseMessage.Content == null)
        {
            throw new Exception("Watt Time Login Failed!");
        }
        string responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
        var settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore
        };
        AccessTokenDto accessToken = JsonConvert.DeserializeObject<AccessTokenDto>(responseContent, settings);
        return accessToken;
    }
}