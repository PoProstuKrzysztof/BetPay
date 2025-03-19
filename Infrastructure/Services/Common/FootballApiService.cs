using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Text.Json.Serialization;

public class FootballApiService : IFootballApiService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<FootballApiService> _logger;
    private readonly JsonSerializerOptions _jsonOptions;

    public FootballApiService(
        HttpClient httpClient,
        IOptions<FootballApiOptions> options,
        ILogger<FootballApiService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;

        _httpClient.BaseAddress = new Uri(options.Value.BaseUrl);
        _httpClient.DefaultRequestHeaders.Add("x-rapidapi-key", options.Value.ApiKey);
        _httpClient.DefaultRequestHeaders.Add("x-rapidapi-host", options.Value.ApiHost);
        _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
            WriteIndented = true
        };
    }

    public async Task<T?> GetAsync<T>(string endpoint, CancellationToken cancellationToken = default) where T : class
    {
        try
        {
            var response = await _httpClient.GetAsync(endpoint, cancellationToken);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            
            _logger.LogInformation("Received API response: {Content}", content);

            var result = JsonSerializer.Deserialize<T>(content, _jsonOptions);

            if (result == null)
            {
                _logger.LogWarning("Deserialization resulted in null object for endpoint: {Endpoint}", endpoint);
            }

            return result;
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Error occurred while calling football API endpoint: {Endpoint}", endpoint);
            throw;
        }
        catch (JsonException ex)
        {
            _logger.LogError(ex, "Error occurred while deserializing response from endpoint: {Endpoint}. Content: {Content}", 
                endpoint, ex.Message);
            throw;
        }
    }
}