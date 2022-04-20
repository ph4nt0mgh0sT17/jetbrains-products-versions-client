using System.Text.Json.Serialization;

namespace JetBrainsProductsVersionsClient.Models;

public class Type
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}