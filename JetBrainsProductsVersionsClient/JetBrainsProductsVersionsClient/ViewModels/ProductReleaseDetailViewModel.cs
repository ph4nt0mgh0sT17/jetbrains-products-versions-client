using System;
using System.Linq;
using CommunityToolkit.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using JetBrainsProductsVersionsClient.Extensions;
using JetBrainsProductsVersionsClient.Models;
using JetBrainsProductsVersionsClient.Requests;
using JetBrainsProductsVersionsClient.Views;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.Logging;

namespace JetBrainsProductsVersionsClient.ViewModels;

public partial class ProductReleaseDetailViewModel : ObservableObject
{
    public Release Release { get; }
    private readonly ILogger<ProductReleaseDetailViewModel> _logger;

    public bool CanOpenNotesLink => Release.NotesLink is not null;
    public bool CanDownload => Release.Downloads is not null;

    public ProductReleaseDetailViewModel(Release? release, ILogger<ProductReleaseDetailViewModel>? logger)
    {
        Guard.IsNotNull(release, nameof(release));
        Guard.IsNotNull(logger, nameof(logger));
        Release = release;
        _logger = logger;
    }

    [ICommand]
    private void OpenNotesLink()
    {
        try
        {
            Release.NotesLink.OpenDefaultBrowserWithLink();
        }

        catch (InvalidOperationException ex)
        {
            _logger.LogError(ex, "The default browser could not be opened due unknown reasons");
        }
    }

    [ICommand(CanExecute = nameof(CanDownload))]
    private async void DownloadRelease()
    {
        Guard.IsNotNull(Release.Downloads);

        var dialogViewModel = new ProductReleaseDownloadsViewModel(
            Ioc.Default.GetService<ILogger<ProductReleaseDownloadsViewModel>>(),
            Release.Downloads.Select(pair => new DownloadDetailRequest(pair.Key, pair.Value)).ToList()
        );

        await DialogHost.Show(dialogViewModel);
    }
}