using System.Text.Json.Serialization;

namespace JetBrainsProductsVersionsClient.Models;

public class Distribution
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("extension")]
    public string? Extension { get; set; }
}