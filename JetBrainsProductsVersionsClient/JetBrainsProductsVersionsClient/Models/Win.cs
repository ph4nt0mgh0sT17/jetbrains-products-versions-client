using System.Text.Json.Serialization;

namespace JetBrainsProductsVersionsClient.Models;

public class Win
{
    [JsonPropertyName("fromBuild")]
    public string? FromBuild { get; set; }

    [JsonPropertyName("link")]
    public string? Link { get; set; }

    [JsonPropertyName("size")]
    public int Size { get; set; }

    [JsonPropertyName("checksumLink")]
    public string? ChecksumLink { get; set; }
}