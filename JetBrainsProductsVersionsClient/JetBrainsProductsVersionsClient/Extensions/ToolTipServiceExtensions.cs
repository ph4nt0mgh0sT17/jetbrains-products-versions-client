using System.Windows;
using System.Windows.Controls;

namespace JetBrainsProductsVersionsClient.Extensions;

public static class ToolTipServiceExtensions
{
    public static void SetupToolTipService()
    {
        EnableDisplayingToolTipWhenControlDisabled();
        DisableToolTipInitialDelay();
    }

    private static void EnableDisplayingToolTipWhenControlDisabled()
    {
        ToolTipService.ShowOnDisabledProperty.OverrideMetadata(
            typeof(FrameworkElement),
            new FrameworkPropertyMetadata(true)
        );
    }

    private static void DisableToolTipInitialDelay()
    {
        ToolTipService.InitialShowDelayProperty.OverrideMetadata(
            typeof(FrameworkElement),
            new FrameworkPropertyMetadata(0)
        );
    }
}