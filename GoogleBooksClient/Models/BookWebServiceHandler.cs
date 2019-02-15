using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GoogleBooksClient.Models
{
    public class BookWebServiceHandler
    {
        public static async Task<ObservableCollection<Book>> SearchBooksAsync(string searchTerm)
        {
            //TODO: Exception-Handling
            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync($"https://www.googleapis.com/books/v1/volumes?q={searchTerm}");

            var apiResult = JsonConvert.DeserializeObject<GoogleBooksAPIResult>(json);

            ObservableCollection<Book> books = new ObservableCollection<Book>();

            foreach (var item in apiResult.items)
            {
                Book newBook = new Book();
                newBook.Title = item.volumeInfo.title;
                newBook.IsFavorite = false;
                newBook.Price = item.saleInfo.listPrice.amount;
                newBook.CoverURL = item.volumeInfo.imageLinks.smallThumbnail;
                newBook.Description = item.volumeInfo.description;
                newBook.Authors = item.volumeInfo.authors;
                books.Add(newBook);

            }
            return books;
        }
    }
}