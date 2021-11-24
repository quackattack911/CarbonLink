using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace CarbonLinkServer.Service.Tesla;

public class TeslaService
{
    private readonly IConfiguration _configuration;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _accessToken;
    private readonly string _id;

    public TeslaService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
    {
        _configuration = configuration;
        _httpClientFactory = httpClientFactory;
        _accessToken = _configuration["Tesla:AccessToken"];
        _id = _configuration["Tesla:Id"];
    }

    public async Task<ChargeStateDto> GetChargeState()
    {
        try
        {
            string chargeRoute = $"api/1/vehicles/{_id}/data_request/charge_state";
            var httpClient = _httpClientFactory.CreateClient("Tesla");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
            var httpResponseMessage = await httpClient.PostAsync(chargeRoute, null);
            if (httpResponseMessage.IsSuccessStatusCode && httpResponseMessage.Content != null)
            {
                string responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                return JsonConvert.DeserializeObject<ChargeStateDto>(responseContent, settings);
            }
            throw new Exception("Get Charge State Failed!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        
    }
}