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

namespace JetBrainsProductsVersionsClient.ViewModels;

public partial class ProductsDashboardViewModel : ObservableObject
{
    [ObservableProperty] [AlsoNotifyChangeFor(nameof(AreProductsEmpty))]
    private ObservableCollection<ProductRequest> _products = new();

    [ObservableProperty] private string? _productName = "";
    [ObservableProperty] private bool _areProductsLoaded;

    private List<ProductRequest>? products;
    private readonly IJetBrainsApiService _jetBrainsApiService;

    public bool AreProductsEmpty => Products.Count == 0;

    public ProductsDashboardViewModel(IJetBrainsApiService jetBrainsApiService)
    {
        _jetBrainsApiService = jetBrainsApiService;
    }

    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        base.OnPropertyChanged(e);

        if (e.PropertyName == nameof(ProductName))
            FilterProducts();
    }

    /// <summary>
    /// Load all <see cref="ProductRequest"/> objects from JetBrains API.
    /// </summary>
    [ICommand]
    private async Task LoadProductsInformation()
    {
        var jetBrainsProducts = await _jetBrainsApiService.RetrieveAllProductsAsync();
        products = new List<ProductRequest>(jetBrainsProducts);
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
    private void FilterProducts()
    {
        if (string.IsNullOrEmpty(ProductName))
        {
            Products = new ObservableCollection<ProductRequest>(products);
        }

        else
        {
            var filteredProducts = products
                .Where(x => x.Name.Contains(ProductName, StringComparison.CurrentCultureIgnoreCase)).ToList();
            Products = new ObservableCollection<ProductRequest>(filteredProducts);
        }
    }
}