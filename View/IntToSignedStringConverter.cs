using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace W40KRogueTrader_BuildPlanner.View
{
    public class IntToSignedStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is int))
            {
                return "";
            }

            if ((int)value > 0)
            {
                return "+" + value.ToString();
            }
            else if ((int)value < 0)
            {
                return new string(value.ToString());
            }
            return "0";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string s = (string)value;
            int convertedValue;

            if (s.StartsWith('+'))
            {
                s = s.Substring(1);
            }

            if (!int.TryParse(s, out convertedValue))
            {
                convertedValue = 0;
            }
            return convertedValue;
        }
    }
}
