using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataTablesInDataGrid
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:DataTablesInDataGrid"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:DataTablesInDataGrid;assembly=DataTablesInDataGrid"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:SectionizedDataGrid/>
    ///
    /// </summary>
    public class SectionizedDataGrid : DataGrid
    {
        public ObservableCollection<MetaColumnm> MetaColumns
        {
            get { return (ObservableCollection<MetaColumnm>)GetValue(MetaColumnsProperty); }
            set { SetValue(MetaColumnsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MetaColumns.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MetaColumnsProperty =
            DependencyProperty.Register("MetaColumns", typeof(ObservableCollection<MetaColumnm>), typeof(SectionizedDataGrid), new PropertyMetadata(null));



        static SectionizedDataGrid()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SectionizedDataGrid), new FrameworkPropertyMetadata(typeof(SectionizedDataGrid)));
        }
    }

    public class MetaColumnm
    {
        public MetaColumnm(int von, int bis, string name)
        {
            Von = von;
            Bis = bis;
            Name = name;
        }

        public int Von { get; set; }
        public int Bis { get; set; }
        public string Name { get; set; }
    }
}
