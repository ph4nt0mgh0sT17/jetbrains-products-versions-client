using System;
using System.Windows;
using CommunityToolkit.Diagnostics;
using CommunityToolkit.Mvvm.DependencyInjection;
using JetBrainsProductsVersionsClient.Requests;
using JetBrainsProductsVersionsClient.ViewModels;

namespace JetBrainsProductsVersionsClient.Views;

public partial class ProductDetailWindow : Window
{
    public ProductDetailWindow(ProductRequest? product)
    {
        Guard.IsNotNull(product, nameof(product));
        InitializeComponent();
        DataContext = new ProductDetailViewModel(product);
    }
    
    public ProductDetailViewModel ViewModel
    {
        get
        {
            if (DataContext is ProductDetailViewModel productsDashboardViewModel)
                return productsDashboardViewModel;

            throw new InvalidOperationException("DataContext of this windows must be ProductsDashboardViewModel.");
        }
    }
}