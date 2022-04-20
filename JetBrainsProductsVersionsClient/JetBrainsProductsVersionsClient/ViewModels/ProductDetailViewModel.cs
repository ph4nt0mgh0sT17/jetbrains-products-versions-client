using System.Diagnostics;
using CommunityToolkit.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JetBrainsProductsVersionsClient.Extensions;
using JetBrainsProductsVersionsClient.Models;
using JetBrainsProductsVersionsClient.Requests;

namespace JetBrainsProductsVersionsClient.ViewModels;

public partial class ProductDetailViewModel : ObservableObject
{
    public ProductRequest Product { get; }

    public ProductDetailViewModel(ProductRequest product)
    {
        Guard.IsNotNull(product, nameof(product));
        Product = product;
    }

    [ICommand]
    private void OpenLink(AdditionalLink? additionalLink)
    {
        Guard.IsNotNull(additionalLink, nameof(additionalLink));
        Guard.IsNotNull(additionalLink.Link, nameof(additionalLink.Link));

        additionalLink.Link.OpenDefaultBrowserWithLink();
    }
}