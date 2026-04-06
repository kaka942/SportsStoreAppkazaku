using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SportsStoreApp.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                // Если параметр "Inverse" - инвертируем результат
                if (parameter is string str && str == "Inverse")
                    return boolValue ? Visibility.Collapsed : Visibility.Visible;

                return boolValue ? Visibility.Visible : Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Visibility visibility && visibility == Visibility.Visible;
        }
    }
}