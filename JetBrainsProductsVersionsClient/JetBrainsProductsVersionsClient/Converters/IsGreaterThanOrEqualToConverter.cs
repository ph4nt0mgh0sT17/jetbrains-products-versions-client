using System;
using System.Globalization;
using System.Windows.Data;

namespace JetBrainsProductsVersionsClient.Converters;

public class IsGreaterThanOrEqualToConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var actualWidth = System.Convert.ToDouble(value);
        var parameterWidth = System.Convert.ToDouble(parameter);

        return actualWidth >= parameterWidth;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}