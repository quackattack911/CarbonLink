using CarbonLinkServer.Service.Database;
using CarbonLinkServer.Service.Tesla;
using CarbonLinkServer.Service.WattTime;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string userAgent = "CarbonLink/0.0.1";
builder.Services.AddHttpClient("Tesla", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://owner-api.teslamotors.com/");
    httpClient.DefaultRequestHeaders.Add(
        HeaderNames.UserAgent, userAgent);
});

builder.Services.AddHttpClient("WattTime", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://api2.watttime.org/v2/");
    httpClient.DefaultRequestHeaders.Add(
        HeaderNames.UserAgent, userAgent);
});

builder.Services.AddSingleton<TeslaService>();

builder.Services.AddSingleton<WattTimeService>();

builder.Services.AddSingleton<DatabaseService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
