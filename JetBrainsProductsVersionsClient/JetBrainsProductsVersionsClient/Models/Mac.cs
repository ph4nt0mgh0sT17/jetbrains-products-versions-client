using System.Text.Json;
using System.Text.Json.Serialization;

namespace JetBrainsProductsVersionsClient.Models;

public class Mac
{
    [JsonPropertyName("fromBuild")]
    public string? FromBuild { get; set; }

    [JsonPropertyName("link")]
    public string? Link { get; set; }

    [JsonPropertyName("size")]
    public int Size { get; set;  }

    [JsonPropertyName("checksumLink")]
    public string? ChecksumLink { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("extension")]
    public string? Extension { get; set; }
}