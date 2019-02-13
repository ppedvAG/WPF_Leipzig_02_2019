using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace LayoutContainer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string _geschlecht = "unbekannt";
        bool _reinigungsmodus = false;

        public MainWindow()
        {
            InitializeComponent();
            #region AttachedProperties per Code-Behind verändern/lesen
            //DockPanel.SetDock(textblockFooter, Dock.Right);
            //DockPanel.GetDock(textblockFooter);
            #endregion

            buttonReinigungStop.AddHandler(Button.MouseUpEvent, new MouseButtonEventHandler((sen, args) =>
            {
                _reinigungsmodus = false;
            }), true);
            
        }

        private void OK_Button_Click(object sender, RoutedEventArgs e)
        {
            string name = textboxName.Text;
            int alter = (int)sliderAlter.Value;
            bool verheiratet = (bool)checkboxVerheiratet.IsChecked;

            string verheiratetString = verheiratet ? "verheiratet" : "ledig";

            MessageBox.Show($"{name} ({alter}), ({_geschlecht}), {verheiratetString}");
        }

        //Bubbling/Tunneling-Events erkennt man daran, dass das Wort "Routed"
        //in den EventArgs enthalten ist
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is RadioButton button)
            {
                _geschlecht = button.Content.ToString();
            }
        }

        //Preview-Ereignisse sind immer Tunneling-Events
        private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_reinigungsmodus)
            {
                //verhindert, dass andere Controls dieses Event erneut behandeln könnnen
                e.Handled = true;
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F4 && !_reinigungsmodus)
            {
                _reinigungsmodus = true;
                Task task = new Task(() =>
                {
                    for (int i = 10; i > 0; i--)
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            this.Title = $"Reinigungsmodus: {i} Sekunden verbleibend";
                        });
                        Thread.Sleep(1000);
                        if (!_reinigungsmodus)
                        {
                            break;
                        }

                        #region ohne Warten auf den Hauptthread
                        //this.Dispatcher.BeginInvoke(new Action(() =>
                        //{
                        //    this.Title = $"Reinigungsmodus: {i} Sekunden verbleibend";

                        //}));
                        #endregion
                    }
                    _reinigungsmodus = false;
                    this.Dispatcher.Invoke(() =>
                    {
                        this.Title = "MainWindow";
                    });
                });
                task.Start();
            }
            else if (_reinigungsmodus)
            {
                e.Handled = true;
            }
        }
    }
}