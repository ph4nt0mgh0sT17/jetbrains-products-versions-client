using System.Text.Json.Serialization;

namespace JetBrainsProductsVersionsClient.Models;

public class Release
{
    [JsonPropertyName("date")]
    public string? Date { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }

    [JsonPropertyName("majorVersion")]
    public string? MajorVersion { get; set; }

    [JsonPropertyName("patches")]
    public Patches? Patches { get; set; }

    [JsonPropertyName("notesLink")]
    public string? NotesLink { get; set; }

    [JsonPropertyName("licenseRequired")]
    public bool LicenseRequired { get; set; }

    [JsonPropertyName("build")]
    public string? Build { get; set; }

    [JsonPropertyName("whatsnew")]
    public string? WhatsNew { get; set; }

    [JsonPropertyName("printableReleaseType")]
    public string? PrintableReleaseType { get; set; }
}