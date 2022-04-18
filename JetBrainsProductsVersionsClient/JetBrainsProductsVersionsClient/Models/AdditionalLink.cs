using System.Text.Json.Serialization;

namespace JetBrainsProductsVersionsClient.Models;

public class AdditionalLink
{
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("link")]
    public string? Link { get; set; }
}