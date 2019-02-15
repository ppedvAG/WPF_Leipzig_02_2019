using GoogleBooksClient.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleBooksClient.Models
{
    public class Book : ModelBase
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetValue(ref _title, value); }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetValue(ref _description, value); }
        }

        private DateTime _publisherDate;
        public DateTime PublisherDate
        {
            get { return _publisherDate; }
            set { SetValue(ref _publisherDate, value); }
        }

        private double _price;
        public double Price
        {
            get { return _price; }
            set { SetValue(ref _price, value); }
        }

        private string _covertURL;
        public string CoverURL
        {
            get { return _covertURL; }
            set { SetValue(ref _covertURL, value); }
        }

        private string[] _authors;
        public string[] Authors
        {
            get { return _authors; }
            set { SetValue(ref _authors, value); }
        }

        private bool _isFavorite;
        public bool IsFavorite
        {
            get { return _isFavorite; }
            set { SetValue(ref _isFavorite, value); }
        }

    }
}
