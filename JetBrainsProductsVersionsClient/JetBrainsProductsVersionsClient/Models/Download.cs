using System.Text.Json.Serialization;

namespace JetBrainsProductsVersionsClient.Models;

public class Download
{
    [JsonPropertyName("link")]
    public string? Link { get; set; }

    [JsonPropertyName("size")]
    public long Size { get; set; }
    
    [JsonPropertyName("checksumLink")]
    public string? ChecksumLink { get; set; }

    public double SizeInMb => (double)Size / 1024L / 1024L;
}