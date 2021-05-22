using BookStore.Model;
using BookStore.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository : IBookRepository
    {
        private IBookProvider bookProvider;

        public BookRepository()
        {
        }
        public BookRepository(IBookProvider _bookprovider)
        {
            bookProvider = _bookprovider;
        }
                
        public bool AddBook(BookDetails bookDetails)
        {
            return true;
        }

        public List<BookDetails> GetAllBooks()
        {
            List<BookDetails> bookList = new List<BookDetails>();
            bookProvider = new BookProvider();
            bookList = bookProvider.AllBooks();
            return bookList;
        }

        public BookDetails GetBookDetails(int id)
        {
            BookDetails bookList = new BookDetails();
            bookProvider = new BookProvider();
            bookList = bookProvider.bookDetails(id);
            return bookList;
        }
    }
}
