using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JetBrainsProductsVersionsClient.Models;

public class Patches
{
    [JsonPropertyName("mac")]
    public List<Mac?>? Mac { get; set; }

    [JsonPropertyName("unix")]
    public List<Unix?>? Unix { get; set; }

    [JsonPropertyName("win")]
    public List<Win?>? Win { get; set; }
}