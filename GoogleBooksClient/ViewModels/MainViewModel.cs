using GoogleBooksClient.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GoogleBooksClient.ViewModels
{
    public class MainViewModel : ModelBase
    {
        //Fody: automatisches PropertyChanged

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

        public MainViewModel()
        {
            SearchBooksCommand = new DelegateCommand(p => SearchBooks(), p => !string.IsNullOrWhiteSpace(SearchTerm));
            FavoriteCommand = new DelegateCommand(p => ShowFavorites());
        }


        public void ShowFavorites()
        {

        }

        public void SearchBooks()
        {

        }
    }
}
