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
using System.Windows.Shapes;

namespace DataTemplates
{
    /// <summary>
    /// Interaction logic for URLInput.xaml
    /// </summary>
    public partial class URLInput : Window
    {
        public string SelectedURL { get; set; }

        public static string ShowURLInputBox(string url)
        {
            URLInput input = new URLInput();
            input.SelectedURL = url;
            if(input.ShowDialog() == true)
            {
                return input.SelectedURL;
            }
            return url;
        }

        public URLInput()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Button_Click_OK(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Button_Click_Abbrechen(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}