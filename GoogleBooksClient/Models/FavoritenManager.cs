using GoogleBooksClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleBooksClient.Models
{
    public class FavoritenManager
    {

        public static ObservableCollection<Book> FavoriteBooks { get; set; }

        const string FileName = "Favoriten.fbs";


        static FavoritenManager()
        {
            if (File.Exists(FileName))
            {
                string json = File.ReadAllText(FileName);
                FavoriteBooks = JsonConvert.DeserializeObject<ObservableCollection<Book>>(json);
            }
            else
            {
                FavoriteBooks = new ObservableCollection<Book>();
            }
        }

        public static bool AddToFavorites(Book book)
        {
            if (FavoriteBooks.Any(b => b.Title == book.Title))
            {
                RemoveFromFavorites(book);
                return false;
            }
            book.IsFavorite = true;
            FavoriteBooks.Add(book);
            return true;
        }

        public static bool RemoveFromFavorites(Book book)
        {
            Book bookToDelete = FavoriteBooks.FirstOrDefault(b => b.Title == book.Title);
            if (bookToDelete == null)
                return false;
            book.IsFavorite = false;
            FavoriteBooks.Remove(bookToDelete);
            return true;
        }

        public static void CheckBooksForFavorites(List<Book> books)
        {
            foreach (var book in books)
            {
                if(FavoriteBooks.Any(b => book.Title == b.Title))
                {
                    book.IsFavorite = true;
                }
            }
        }

        public static void SaveFavorites()
        {
            string json = JsonConvert.SerializeObject(FavoriteBooks);
            File.WriteAllText(FileName, json);
        }
    }
}