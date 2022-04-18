using System;
using System.Diagnostics;
using CommunityToolkit.Diagnostics;

namespace JetBrainsProductsVersionsClient.Extensions;

public static class ProcessExtensions
{
    /// <summary>
    /// Opens default browser with given link
    /// </summary>
    /// <param name="link">A link to be opened.</param>
    /// <exception cref="InvalidOperationException">If browser cannot be open.</exception>
    public static void OpenDefaultBrowserWithLink(string? link)
    {
        Guard.IsNotNull(link, nameof(link));

        try
        {
            var process = new Process();
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.FileName = link;
            process.Start();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Cannot open the link: {link}", ex);
        }
    }
}