using System;
using System.Globalization;
using System.Windows.Data;

namespace Calculator.ViewModel.Converters
{
    /// <summary>
    /// Converter for value length to proper font size
    /// </summary>
    public class ValueLengthToFontSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var length = 0;

            if (value is string)
            {
                length = value.ToString().Length;
            }
            else if(value is double?)
            {
                length = (value as double?).Value.ToString(CultureInfo.InvariantCulture).Length;
            }

            var size = 50 - (double)(length - 9) * 3.0;

            return size < 50 ? size : 50;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
