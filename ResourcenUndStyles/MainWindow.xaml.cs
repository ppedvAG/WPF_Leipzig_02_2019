using System;
using System.Collections.Generic;
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

namespace ResourcenUndStyles
{

    public enum Farben : short { Rot, Gelb, Grün}

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Sprachen_Click(object sender, RoutedEventArgs e)
        {
            if(e.OriginalSource is MenuItem item)
            {
                string filename = item.Tag.ToString();

                Application.Current.Resources.MergedDictionaries[0].Source = new Uri($"pack://application:,,,/Sprachen/{filename}");
                //new MainWindow().Show();
                //this.Close();
            }
        }

        private void MenuItem_Styles_Click(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is MenuItem item)
            {
                string filename = item.Tag.ToString();

                Application.Current.Resources.MergedDictionaries[1].Source = new Uri($"pack://siteOfOrigin:,,,/Styles/{filename}");
                new MainWindow().Show();
                this.Close();
            }
        }
    }
}
