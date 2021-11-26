using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Web;

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

    private async Task<AccessTokenDto?> Login()
    {
        string loginRoute = "login";
        var authenticationString = $"{_username}:{_password}";
        var base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(authenticationString));
        var request = new HttpRequestMessage(HttpMethod.Get, loginRoute);
        request.Headers.Add("Authorization", "Basic" + base64EncodedAuthenticationString);
        var httpClient = _httpClientFactory.CreateClient("WattTime");
        var httpResponseMessage = await httpClient.SendAsync(request);
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
        AccessTokenDto? accessToken = JsonConvert.DeserializeObject<AccessTokenDto>(responseContent, settings);
        return accessToken;
    }

    public async Task<RealTimeEmissionsIndexDto?> GetRealTimeEmissions()
    {
        string realTimeEmissionRoute = "index";
        var uriBuilder = new UriBuilder(realTimeEmissionRoute);
        NameValueCollection query = HttpUtility.ParseQueryString(uriBuilder.Query);
        query["latitude"] = _configuration["WattTime:Latitude"];
        query["longitude"] = _configuration["WattTime:Longitude"];
        uriBuilder.Query = query.ToString();
        var request = new HttpRequestMessage(HttpMethod.Get, uriBuilder.ToString());
        var accessToken = await Login();
        request.Headers.Add("Authorization", "Bearer" + accessToken.Token);
        var httpClient = _httpClientFactory.CreateClient("WattTime");
        var httpResponseMessage = await httpClient.SendAsync(request);
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
        RealTimeEmissionsIndexDto? realTimeEmissionsIndexDto = JsonConvert.DeserializeObject<RealTimeEmissionsIndexDto>(responseContent, settings);
        return realTimeEmissionsIndexDto;
    }
}