using System.Collections.Generic;
using System.Text.Json.Serialization;
using JetBrainsProductsVersionsClient.Models;

namespace JetBrainsProductsVersionsClient.Requests;

public class ProductRequest
{
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("releases")]
    public List<Release?>? Releases { get; set; }

    [JsonPropertyName("forSale")]
    public bool? IsForSale { get; set; }

    [JsonPropertyName("productFamilyName")]
    public string? ProductFamilyName { get; set; }

    [JsonPropertyName("additionalLinks")]
    public List<AdditionalLink?>? AdditionalLinks { get; set; }

    [JsonPropertyName("intellijProductCode")]
    public string? IntellijProductCode { get; set; }

    [JsonPropertyName("alternativeCodes")]
    public List<string?>? AlternativeCodes { get; set; }

    [JsonPropertyName("salesCode")]
    public string? SalesCode { get; set; }

    [JsonPropertyName("link")]
    public string? Link { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("tags")]
    public List<Tag?>? Tags { get; set; }

    [JsonPropertyName("types")]
    public List<Type?>? Types { get; set; }

    [JsonPropertyName("categories")]
    public List<string?>? Categories { get; set; }
    
    [JsonPropertyName("distributions")]
    public Dictionary<string, Distribution>? Distributions { get; set; }
}