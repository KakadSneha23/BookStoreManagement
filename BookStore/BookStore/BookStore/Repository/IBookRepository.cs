using BookStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public interface IBookRepository
    {
        public bool AddBook(BookDetails bookDetails);
        public List<BookDetails> GetAllBooks();
        public BookDetails GetBookDetails(int id);
    }
}
