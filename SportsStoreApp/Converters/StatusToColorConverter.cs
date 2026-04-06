using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace SportsStoreApp.Converters
{
    public class StatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string status = value as string;

            switch (status?.ToLower())
            {
                case "в наличии":
                    return new SolidColorBrush(Color.FromRgb(76, 175, 80)); // Зеленый
                case "мало":
                    return new SolidColorBrush(Color.FromRgb(255, 152, 0)); // Оранжевый
                case "нет в наличии":
                    return new SolidColorBrush(Color.FromRgb(244, 67, 54)); // Красный
                default:
                    return new SolidColorBrush(Color.FromRgb(158, 158, 158)); // Серый
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}