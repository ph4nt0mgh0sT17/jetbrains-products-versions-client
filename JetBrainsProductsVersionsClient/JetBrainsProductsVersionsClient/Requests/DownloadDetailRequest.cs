using System;
using JetBrainsProductsVersionsClient.Models;

namespace JetBrainsProductsVersionsClient.Requests;

public class DownloadDetailRequest
{
    public string PlatformKey { get; }
    public Download Download { get; }

    public DownloadDetailRequest(string? platformKey, Download? download)
    {
        PlatformKey = platformKey ?? throw new ArgumentNullException(nameof(platformKey));
        Download = download ?? throw new ArgumentNullException(nameof(download));
    }
}