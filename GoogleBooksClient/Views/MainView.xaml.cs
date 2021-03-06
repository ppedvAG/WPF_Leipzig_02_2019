﻿using GoogleBooksClient.Helper;
using GoogleBooksClient.Models;
using GoogleBooksClient.ViewModels;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GoogleBooksClient.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            if(this.DataContext is MainViewModel model)
            {
                model.CloseApplication += Model_CloseApplication;
                model.PageChanged += Model_RemovePage; 
                model.RemovePage += Model_PageChanged;
                model.RootFrame = rootFrame;
            }

        }

        private void Model_RemovePage(object sender, EventArgs e)
        {
            DoubleAnimation animation = new DoubleAnimation(-rootFrame.ActualWidth, 0, new Duration(TimeSpan.FromSeconds(1)), FillBehavior.HoldEnd);

            frameTransform.BeginAnimation(TranslateTransform.XProperty, animation);
        }

        private void Model_PageChanged(object sender, EventArgs e)
        {
            DoubleAnimation animation = new DoubleAnimation(0, rootFrame.ActualWidth, new Duration(TimeSpan.FromSeconds(1)), FillBehavior.HoldEnd);
            frameTransform.BeginAnimation(TranslateTransform.XProperty, animation);
           
        }

        

        private void Model_CloseApplication(object sender, EventArgs e)
        {
            Environment.Exit(0);
            this.Close();
        }
        
        private void Window_Closed(object sender, EventArgs e)
        {
            FavoritenManager.SaveFavorites();
        }
    }
}
