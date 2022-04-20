using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Documents;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JetBrainsProductsVersionsClient.Requests;
using JetBrainsProductsVersionsClient.Services;
using JetBrainsProductsVersionsClient.Views;
using Microsoft.Extensions.Logging;

namespace JetBrainsProductsVersionsClient.ViewModels;

public partial class ProductsDashboardViewModel : ObservableObject
{
    [ObservableProperty] [AlsoNotifyChangeFor(nameof(AreProductsEmpty))]
    private ObservableCollection<ProductRequest> _products = new();

    [ObservableProperty]
    private string _productName = "";

    [ObservableProperty]
    private bool _areProductsLoaded;

    private List<ProductRequest> _allJetBrainsProducts = new();

    private readonly IJetBrainsApiService _jetBrainsApiService;
    private readonly ILogger<ProductsDashboardViewModel> _logger;

    public bool AreProductsEmpty => Products.Count == 0;

    public ProductsDashboardViewModel(IJetBrainsApiService jetBrainsApiService,
        ILogger<ProductsDashboardViewModel> logger)
    {
        _jetBrainsApiService = jetBrainsApiService;
        _logger = logger;
    }

    partial void OnProductNameChanged(string productName)
    {
        FilterProducts(productName);
    }

    /// <summary>
    /// Load all <see cref="ProductRequest"/> objects from JetBrains API.
    /// </summary>
    [ICommand]
    private async Task LoadProductsInformation()
    {
        var jetBrainsProducts = await _jetBrainsApiService.RetrieveAllProductsAsync();

        _logger.LogInformation("JetBrains products are successfully loaded");

        _allJetBrainsProducts = new List<ProductRequest>(jetBrainsProducts);
        Products = new ObservableCollection<ProductRequest>(jetBrainsProducts);
        AreProductsLoaded = true;
    }

    /// <summary>
    /// Opens <see cref="ProductDetailWindow"/>.
    /// </summary>
    /// <param name="productRequest">The current <see cref="ProductRequest"/> that will be shown in the <see cref="ProductDetailWindow"/>.</param>
    [ICommand]
    private void OpenProductDetailWindow(ProductRequest productRequest)
    {
        new ProductDetailWindow(productRequest).ShowDialog();
    }

    /// <summary>
    /// Filter products everytime the <see cref="ProductName"/> is changed in the UI.
    /// Also displays all products if <see cref="ProductName"/> is empty or null.
    /// </summary>
    private void FilterProducts(string productName)
    {
        if (productName == "")
        {
            Products = new ObservableCollection<ProductRequest>(_allJetBrainsProducts);
        }

        else
        {
            var filteredProducts = _allJetBrainsProducts
                .Where(x => x.Name!.Contains(productName, StringComparison.CurrentCultureIgnoreCase)).ToList();
            Products = new ObservableCollection<ProductRequest>(filteredProducts);
        }
    }
}