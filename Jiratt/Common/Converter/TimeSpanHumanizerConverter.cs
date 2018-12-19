using System;
using System.Globalization;
using System.Windows.Data;
using Humanizer;

namespace Jiratt.Common.Converter {
    /// <summary>
    /// Converter um eine <see cref="TimeSpan"/> in ein lesbares Format zu überführen.
    /// </summary>
    public class TimeSpanHumanizerConverter : IValueConverter {
        /// <summary>
        /// TimeSpan -> Text
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is TimeSpan time) {
                return time.Humanize(3);
            }

            return value;
        }

        /// <summary>
        /// [inop]
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}