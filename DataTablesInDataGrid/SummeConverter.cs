using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DataTablesInDataGrid
{
    public class SummeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int summe = 0;
            foreach (var item in values)
            {
                if(int.TryParse(item?.ToString(), out int ivalue))
                {
                    summe += ivalue;
                }
            }
            return summe.ToString();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
