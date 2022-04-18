using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace JetBrainsProductsVersionsClient.Converters;

public class ReversedBoolToVisibilityConverter: IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool val)
        {
            return val ? Visibility.Hidden : Visibility.Visible;
        }

        throw new InvalidOperationException(
            "The ReversedBoolToVisibilityConverter only accepts bool values to convert it into Visibility objects."
        );
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}