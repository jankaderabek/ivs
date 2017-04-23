using System;
using System.Globalization;
using System.Windows.Data;

namespace Calculator.ViewModel.Converters
{
    /// <summary>
    /// Class for conversion double to console short string
    /// </summary>
    public class DoubleToShortStringConverter : IValueConverter
    {
        /// <summary>
        /// Converts value to view
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Converts value back from view
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
