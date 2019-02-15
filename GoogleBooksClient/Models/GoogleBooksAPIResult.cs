using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleBooksClient.Models
{

    public class GoogleBooksAPIResult
    {
        public Item[] items { get; set; }
    }

    public class Item
    {
       
        public Volumeinfo volumeInfo { get; set; }
        public Saleinfo saleInfo { get; set; }
    }

    public class Volumeinfo
    {
        public string title { get; set; }
        public string[] authors { get; set; }
        public string publishedDate { get; set; }
        public string description { get; set; }
      
        public Imagelinks imageLinks { get; set; }
    }
   
    public class Imagelinks
    {
        public string smallThumbnail { get; set; }
    }

    public class Saleinfo
    {
        public Listprice listPrice { get; set; }
    }

    public class Listprice
    {
        public float amount { get; set; }
    }
}
