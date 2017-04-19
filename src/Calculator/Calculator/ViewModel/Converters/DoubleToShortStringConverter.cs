using System;
using System.Globalization;
using System.Windows.Data;

namespace Calculator.ViewModel.Converters
{
    public class DoubleToShortStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string)
            {
                return value.ToString();
            }
            else
            {
                return (value as double?)?.ToString();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
