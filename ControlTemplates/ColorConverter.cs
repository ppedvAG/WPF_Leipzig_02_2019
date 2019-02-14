using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace ControlTemplates
{
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is SolidColorBrush brush)
            {
              
                byte r = Math.Min(brush.Color.R, (byte)(brush.Color.R - 20));
                byte g = Math.Min(brush.Color.G, (byte)(brush.Color.G - 20));
                byte b = Math.Min(brush.Color.B, (byte)(brush.Color.B - 20));

                return new SolidColorBrush(Color.FromRgb(r, g, b));
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
