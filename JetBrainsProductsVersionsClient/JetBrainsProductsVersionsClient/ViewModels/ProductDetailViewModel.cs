using System;
using System.Diagnostics;
using CommunityToolkit.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JetBrainsProductsVersionsClient.Extensions;
using JetBrainsProductsVersionsClient.Models;
using JetBrainsProductsVersionsClient.Requests;
using JetBrainsProductsVersionsClient.Views;
using Microsoft.Extensions.Logging;

namespace JetBrainsProductsVersionsClient.ViewModels;

public partial class ProductDetailViewModel : ObservableObject
{
    public ProductRequest Product { get; }
    private readonly ILogger<ProductDetailViewModel> _logger;

    public ProductDetailViewModel(ProductRequest? product, ILogger<ProductDetailViewModel>? logger)
    {
        Guard.IsNotNull(product, nameof(product));
        Guard.IsNotNull(logger, nameof(logger));
        Product = product;
        _logger = logger;
    }

    [ICommand]
    private void OpenLink(AdditionalLink? additionalLink)
    {
        Guard.IsNotNull(additionalLink, nameof(additionalLink));
        Guard.IsNotNull(additionalLink.Link, nameof(additionalLink.Link));

        TryOpenDefaultBrowserWithLink(additionalLink);
    }
    
    [ICommand]
    private void OpenReleaseDetail(Release? release)
    {
        Guard.IsNotNull(release, nameof(release));

        new ProductReleaseDetailWindow(release).ShowDialog();
    }

    private void TryOpenDefaultBrowserWithLink(AdditionalLink additionalLink)
    {
        try
        {
            additionalLink.Link.OpenDefaultBrowserWithLink();
        }

        catch (InvalidOperationException ex)
        {
            _logger.LogError(ex, "The default browser could not be opened due unknown reasons");
        }
    }
}