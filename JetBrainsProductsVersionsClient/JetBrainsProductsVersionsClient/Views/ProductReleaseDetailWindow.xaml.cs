using System;
using System.Windows;
using CommunityToolkit.Diagnostics;
using CommunityToolkit.Mvvm.DependencyInjection;
using JetBrainsProductsVersionsClient.Models;
using JetBrainsProductsVersionsClient.ViewModels;
using Microsoft.Extensions.Logging;

namespace JetBrainsProductsVersionsClient.Views;

public partial class ProductReleaseDetailWindow : Window
{
    public ProductReleaseDetailWindow(Release? release)
    {
        Guard.IsNotNull(release, nameof(release));
        InitializeComponent();
        DataContext = new ProductReleaseDetailViewModel(
            release, Ioc.Default.GetService<ILogger<ProductReleaseDetailViewModel>>()
        );
    }
    
    public ProductReleaseDetailViewModel ViewModel
    {
        get
        {
            if (DataContext is ProductReleaseDetailViewModel productReleaseDetailViewModel)
                return productReleaseDetailViewModel;

            throw new InvalidOperationException("DataContext of this windows must be ProductReleaseDetailViewModel.");
        }
    }
}