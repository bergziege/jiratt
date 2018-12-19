using System;
using System.Globalization;
using System.Windows.Data;
using Humanizer;

namespace Jiratt.Common.Converter {
    public class TimeSpanHumanizerConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is TimeSpan time) {
                return time.Humanize(3);
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}