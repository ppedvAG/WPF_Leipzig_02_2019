using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace UserControls
{

    public enum Kontaktarten { EMail, Fax, Post };
    public enum Farben { Red, Green, Yellow };

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //this.Title = "Titel";
            //this.SetValue(Window.TitleProperty, "Titel");

            //string title = this.Title;
            //title = (string)GetValue(Window.TitleProperty);

            //this.DataContext = Kontaktarten.EMail;

        }
    }

    public class Person : INotifyPropertyChanged
    {
        private Kontaktarten _kontaktart;

        public Kontaktarten Kontaktart
        {
            get => _kontaktart;
            set
            {
                _kontaktart = value;
            }
        }

        private Farben _lieblingsfarbe;

        public event PropertyChangedEventHandler PropertyChanged;

        public Farben Lieblingsfarbe
        {
            get { return _lieblingsfarbe; }
            set { _lieblingsfarbe = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Lieblingsfarbe)));
            }
        }


    }
}
