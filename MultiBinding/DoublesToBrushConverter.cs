using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace MultiBinding
{
    public class DoublesToBrushConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            byte red = byte.Parse(values[0].ToString());
            byte blue = byte.Parse(values[1].ToString());
            byte green = byte.Parse(values[2].ToString());

            return new SolidColorBrush(Color.FromRgb(red, blue, green));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
