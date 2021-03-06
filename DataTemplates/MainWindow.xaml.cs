﻿using System;
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

namespace DataTemplates
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //jede Liste, die gebunden werde soll, immer als ObservableCollection anlegen!!!
        ObservableCollection<Flugzeug> _flugzeugliste = new ObservableCollection<Flugzeug>()
        {
            new Flugzeug("A320",38 ,Flugzeug.FlugzeugTyp.Passagier,"https://store.x-plane.org/assets/images/files/peterhager/320neo/01.jpg")
        }; 

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = _flugzeugliste;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _flugzeugliste.Add(new Flugzeug());
        }
    }
}
