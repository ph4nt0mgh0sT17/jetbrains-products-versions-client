using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace JetBrainsProductsVersionsClient.Converters;

public class BoolToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool val)
        {
            return val ? Visibility.Visible : Visibility.Hidden;
        }

        throw new InvalidOperationException(
            "The BoolToVisibilityConverter only accepts bool values to convert it into Visibility objects."
        );
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}