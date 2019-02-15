using GoogleBooksClient.Models;
using System;
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

namespace GoogleBooksClient.Helper
{
    /// <summary>
    /// Interaction logic for BooksPresenter.xaml
    /// </summary>
    public partial class BooksPresenter : UserControl
    {



        public ICommand ButtonCommand
        {
            get { return (ICommand)GetValue(ButtonCommandProperty); }
            set { SetValue(ButtonCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ButtonCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonCommandProperty =
            DependencyProperty.Register("ButtonCommand", typeof(ICommand), typeof(BooksPresenter), new PropertyMetadata(null));





        public ObservableCollection<Book> Books
        {
            get { return (ObservableCollection<Book>)GetValue(BooksProperty); }
            set { SetValue(BooksProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Books.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BooksProperty =
            DependencyProperty.Register("Books", typeof(ObservableCollection<Book>), typeof(BooksPresenter), new PropertyMetadata(null));





        public BooksPresenter()
        {
            InitializeComponent();
            datagrid.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.DataContext is Book book)
                {
                    ButtonCommand.Execute(book);
                }
            }
        }
    }
}
