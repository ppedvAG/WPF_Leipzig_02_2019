using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //DataTable erstellen
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("01", typeof(int)));
            table.Columns.Add(new DataColumn("02", typeof(int)));
            table.Columns.Add(new DataColumn("03", typeof(int)));
            table.Rows.Add(2, 5, 4);
            table.Rows.Add(4, 10, 12);
            table.Rows.Add(4, 12, 24);


            DataView view = table.AsDataView();

            var sds = view[0];

            datagrid.ItemsSource = table.AsDataView();

            ObservableCollection<MitarbeiterArbeitszeit> Mitarbeiterliste = new ObservableCollection<MitarbeiterArbeitszeit>()
            {
                new MitarbeiterArbeitszeit("Susi", 2, 5, 10),
                new MitarbeiterArbeitszeit("Paula", 2, 5, 20),
                new MitarbeiterArbeitszeit("Jennifer", 2, 15, 10),
            };
            datagrid2.ItemsSource = Mitarbeiterliste;



            DataGrid newGrid = new DataGrid();
            DataGridTemplateColumn neueColumn = new DataGridTemplateColumn();
            neueColumn.Header = "Beschriftung";
            DataTemplate dataTemplate = new DataTemplate();

            FrameworkElementFactory textbox = new FrameworkElementFactory(typeof(TextBox));
            textbox.SetBinding(TextBox.TextProperty, new Binding("[0]")
                { UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged, Mode = BindingMode.TwoWay }
            );

            dataTemplate.VisualTree = textbox;

            neueColumn.CellTemplate = dataTemplate;


            newGrid.Columns.Add(neueColumn);
        }
    }

    public class MitarbeiterArbeitszeit : INotifyPropertyChanged
    {
        public string Name { get; set; }
        private int _januar;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Januar
        {
            get { return _januar; }
            set
            {
                _januar = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Januar)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Summe)));
            }
        }

        private int _februar;

        public int Februar
        {
            get { return _februar; }
            set
            {
                _februar = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Februar)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Summe)));
            }
        }

        private int _märz;

        public MitarbeiterArbeitszeit(string name, int januar, int februar, int märz)
        {
            Name = name;
            Januar = januar;
            Februar = februar;
            März = märz;
        }

        public int März
        {
            get { return _märz; }
            set
            {
                _märz = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(März)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Summe)));
            }
        }

        public int Summe => Januar + Februar + März;
    }

}
