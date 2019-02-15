using GoogleBooksClient.Helper;
using GoogleBooksClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleBooksClient.ViewModels
{
    public class BooksResultViewModel : ModelBase
    {

        private ObservableCollection<Book> _books;
        public ObservableCollection<Book> Books
        {
            get { return _books; }
            set { SetValue(ref _books,value); }
        }

        public DelegateCommand AddFavoriteCommand { get; set; }

        public BooksResultViewModel(ObservableCollection<Book> books) : this()
        {
            Books = books;
        }

        public BooksResultViewModel()
        {
            AddFavoriteCommand = new DelegateCommand(p =>
            {
                if (p is Book book)
                {
                    AddBookToFavorites(book);
                }
            });
        }


        public void AddBookToFavorites(Book book)
        {
            FavoritenManager.AddToFavorites(book);
        }
    }
}
