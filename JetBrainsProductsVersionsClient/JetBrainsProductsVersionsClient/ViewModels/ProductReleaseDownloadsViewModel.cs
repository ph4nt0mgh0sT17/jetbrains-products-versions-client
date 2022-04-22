using System.Collections.Generic;
using CommunityToolkit.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using JetBrainsProductsVersionsClient.Models;
using JetBrainsProductsVersionsClient.Requests;
using Microsoft.Extensions.Logging;

namespace JetBrainsProductsVersionsClient.ViewModels;

public partial class ProductReleaseDownloadsViewModel : ObservableObject
{
    public List<DownloadDetailRequest> Downloads { get; }
    private readonly ILogger<ProductReleaseDownloadsViewModel> _logger;

    public ProductReleaseDownloadsViewModel(
        ILogger<ProductReleaseDownloadsViewModel>? logger, 
        List<DownloadDetailRequest> downloads)
    {
        Guard.IsNotNull(logger, nameof(logger));
        Guard.IsNotNull(downloads, nameof(downloads));
        
        _logger = logger;
        Downloads = downloads;
    }
}