using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace AnimalFarm
{
    public class BoolToMale : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((bool)value) ? "Male" : "Female";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Equals(true, value)
                ? "Male" : "Female";
        }
    }

    public class BoolToStatus : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((bool)value) ? "In work" : "Don't working";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Equals(true, value)
                ? "Male" : "Female";
        }
    }
}
