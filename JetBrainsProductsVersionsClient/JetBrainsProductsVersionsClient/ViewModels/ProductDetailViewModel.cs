using CommunityToolkit.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using JetBrainsProductsVersionsClient.Requests;

namespace JetBrainsProductsVersionsClient.ViewModels;

public class ProductDetailViewModel : ObservableObject
{
    public ProductRequest Product { get; }

    public ProductDetailViewModel(ProductRequest product)
    {
        Guard.IsNotNull(product, nameof(product));
        Product = product;
    }
}