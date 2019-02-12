using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace ElementBinding
{


    public class DoubleToBrushConverter : IValueConverter
    {
        public static DoubleToBrushConverter _converter = new DoubleToBrushConverter
        {
            TargetBrush = Brushes.Fuchsia,
            TargetNumber = 20,
            DefaultBrush = Brushes.Green
        };
        public static DoubleToBrushConverter Converter => _converter;

        public double TargetNumber { get; set; } = 30;
        public Brush TargetBrush { get; set; } = Brushes.Red;
        public Brush DefaultBrush { get; set; } = Brushes.Black;

        //Source -> Target (Slider.Value -> TextBlock.Foreground)
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double doubleValue)
            {
                if (doubleValue == TargetNumber)
                {
                    return TargetBrush;
                }
            }
            return DefaultBrush;
        }

        //Target -> Source (TextBlock.Foreground -> Slider.Value)
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
