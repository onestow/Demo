using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApp1.Converters
{
    public class DateTimeToStringConverter : IValueConverter
    {
        private static string[] chDayOfWeek = { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var date = value as DateTime?;
            if (parameter.ToString() == "DayOfWeek")
                return chDayOfWeek[(int)date.Value.DayOfWeek];
            else
                return date.Value.ToString(parameter.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
