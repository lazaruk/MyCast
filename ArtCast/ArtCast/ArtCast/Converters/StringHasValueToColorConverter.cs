using ArtCast.Helpers;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace ArtCast.Converters
{
    public class StringHasValueToColorConverter : IValueConverter
    {
        public Color TrueColor { get; set; }
        public Color FalseColor { get; set; }
        public string IgnoredValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var str = value as string;
            if (IgnoredValue != null && str == IgnoredValue) str = null;
            return str.HasValue() ? TrueColor : FalseColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
