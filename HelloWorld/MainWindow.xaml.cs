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

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        Random _random = new Random();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello World!");
            Button neuerButton = new Button();
            neuerButton.Content = "Click mich bitte auch";
            neuerButton.HorizontalAlignment = (HorizontalAlignment)_random.Next(0, 4);
            neuerButton.VerticalAlignment = (VerticalAlignment)_random.Next(0, 4);
            neuerButton.Click += NeuerButton_Click;
            neuerButton.Margin = new Thickness(10, 0, 0, 0);
            //Parser nutzt den Typeconverter:
            //neuerButton.Margin = (Thickness) new ThicknessConverter().ConvertFromString("10 0 0 0");

            grid1.Children.Add(neuerButton);
        }

        private void NeuerButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Neuer Button wurde geklickt");
        }

        private void Dummy_Button_Click(object sender, RoutedEventArgs e)
        {
            button2.Visibility = Visibility.Visible;
        }
    }
}
