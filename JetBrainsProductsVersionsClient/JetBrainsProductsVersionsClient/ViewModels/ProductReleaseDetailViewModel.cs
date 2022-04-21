using System;
using CommunityToolkit.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JetBrainsProductsVersionsClient.Extensions;
using JetBrainsProductsVersionsClient.Models;
using JetBrainsProductsVersionsClient.Requests;
using JetBrainsProductsVersionsClient.Views;
using Microsoft.Extensions.Logging;

namespace JetBrainsProductsVersionsClient.ViewModels;

public partial class ProductReleaseDetailViewModel : ObservableObject
{
    public Release Release { get; }
    private readonly ILogger<ProductReleaseDetailViewModel> _logger;

    public bool CanOpenNotesLink => Release.NotesLink is not null;
    public bool CanDownload => false;

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
    private void DownloadRelease()
    {
        // TODO: Open dialog window with possibilites what to download
    }
}