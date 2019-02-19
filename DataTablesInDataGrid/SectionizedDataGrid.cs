using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        public ObservableCollection<MetaColumn> MetaColumns
        {
            get { return (ObservableCollection<MetaColumn>)GetValue(MetaColumnsProperty); }
        }

        // Using a DependencyProperty as the backing store for MetaColumns.  This enables animation, styling, binding, etc...
        public static readonly DependencyPropertyKey MetaColumnsPropertyKey =
            DependencyProperty.RegisterReadOnly("MetaColumns", typeof(ObservableCollection<MetaColumn>), typeof(SectionizedDataGrid), new PropertyMetadata(null));

        public static readonly DependencyProperty MetaColumnsProperty = MetaColumnsPropertyKey.DependencyProperty;

        public SectionizedDataGrid()
        {
            this.SizeChanged += MainGrid_SizeChanged;
            SetValue(MetaColumnsPropertyKey, new ObservableCollection<MetaColumn>());
        }

        private async void MainGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //Das SizeChanged-Event feuert zu zeitig, erst ca. 1 Sekunde danach
            //sind die Datagrid-Columns neu gezeichnet und geben den korrekten Wert für ActualWidth zurück
            //TODO: Event finden, was erst gefeuert wird, nachdem die Spaltenbreiten fertig berechnet wurden
            await Task.Delay(1000);
            DrawMetaColumns();
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            if (e.Property.Name == nameof(CellsPanelHorizontalOffset))
            {
                DrawMetaColumns();
            }
            base.OnPropertyChanged(e);
        }

        public void DrawMetaColumns()
        {
            SectionizedDataGrid sgrid = this;
            ScrollViewer viewer = sgrid.GetTemplateChild("DG_ScrollViewer") as ScrollViewer;

            Grid grid = viewer.Template.FindName("metaHeaders", viewer) as Grid;
            if (grid == null)
            {
                return;
            }

            grid.Margin = new Thickness(sgrid.CellsPanelHorizontalOffset, 0, 0, 0);

            grid.Children.Clear();
            grid.ColumnDefinitions.Clear();
            foreach (var column in sgrid.Columns)
            {
                //ermittle die Anzahl und Breite der MetaGrid-Spalten anhand der ActualWidth jeder Spalte im DataGrid
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(column.ActualWidth) });
            }
            foreach (MetaColumn item in sgrid.MetaColumns)
            {
                Border newBorder = new Border
                {
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(1)
                };
                TextBlock newMetaHeader = new TextBlock
                {
                    Text = item.Name,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
                newBorder.Child = newMetaHeader;
                Grid.SetColumn(newBorder, item.Von);
                Grid.SetColumnSpan(newBorder, item.Span);
                grid.Children.Add(newBorder);
            }
        }

        static SectionizedDataGrid()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SectionizedDataGrid), new FrameworkPropertyMetadata(typeof(SectionizedDataGrid)));
        }
    }

    public class MetaColumn
    {
        public int Von { get; set; }
        public int Bis { get; set; }
        public string Name { get; set; }
        public int Span => Bis - Von + 1;


        public MetaColumn(int von, int bis, string name)
        {
            Von = von;
            Bis = bis;
            Name = name;
        }

        public MetaColumn()
        {

        }
    }
}