using GoogleBooksClient.Helper;
using GoogleBooksClient.Models;
using GoogleBooksClient.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GoogleBooksClient.ViewModels
{
    public class MainViewModel : ModelBase
    {
        //Fody: automatisches PropertyChanged

        public event EventHandler CloseApplication;
        public event EventHandler PageChanged;
        public event EventHandler RemovePage;

        private string _searchTerm;
        public string SearchTerm
        {
            get { return _searchTerm; }
            set { SetValue(ref _searchTerm, value); }
        }

        private Frame _rootFrame;
        public Frame RootFrame
        {
            get { return _rootFrame; }
            set { SetValue(ref _rootFrame, value); }
        }

        public DelegateCommand FavoriteCommand { get; set; }
        public DelegateCommand SearchBooksCommand { get; set; }
        public DelegateCommand ExitCommand { get; set; }

        public MainViewModel()
        {
            SearchBooksCommand = new DelegateCommand(p => SearchBooks(), p => !string.IsNullOrWhiteSpace(SearchTerm));
            FavoriteCommand = new DelegateCommand(p => ShowFavorites());
            ExitCommand = new DelegateCommand(p =>
            {
                CloseApplication?.Invoke(this, EventArgs.Empty);
            });
        }

        public void ShowFavorites()
        {
            //View bauen
            FavoriteView view = new FavoriteView();
            //Model bauen
            BooksResultViewModel model = new BooksResultViewModel(FavoritenManager.FavoriteBooks);
            //Model mit View verbinden
            view.DataContext = model;

            RootFrame.Navigate(view);
        }

        public async void SearchBooks()
        {
            RemovePage.Invoke(this, EventArgs.Empty);
            ObservableCollection<Book> books = await BookWebServiceHandler.SearchBooksAsync(SearchTerm);
            if(books.Count == 0)
            {
                MessageBox.Show("Keine Treffer!");
                PageChanged?.Invoke(this, EventArgs.Empty);
                return;
            }
            //nächste Page laden
            BooksResultView view = new BooksResultView();
            BooksResultViewModel model = new BooksResultViewModel(books);
            view.DataContext = model;
            RootFrame.Navigate(view);
            PageChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
