using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using CommunityToolkit.Diagnostics;
using JetBrainsProductsVersionsClient.Requests;

namespace JetBrainsProductsVersionsClient.Services;

public class JetBrainsApiService : IJetBrainsApiService
{
    private readonly HttpClient _httpClient;

    public JetBrainsApiService()
    {
        _httpClient = CreateJetBrainsDataServiceHttpClient();
    }

    public async Task<List<ProductRequest>> RetrieveAllProductsAsync()
    {
        var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, "/products"));
        var jsonText = await response.Content.ReadAsStringAsync();

        Guard.IsNotNull(jsonText, nameof(jsonText));

        return JsonSerializer.Deserialize<List<ProductRequest>>(jsonText) ??
               throw new InvalidOperationException("The products cannot be null.");
    }

    private HttpClient CreateJetBrainsDataServiceHttpClient()
    {
        return new HttpClient
        {
            BaseAddress = new Uri("https://data.services.jetbrains.com/")
        };
    }
}