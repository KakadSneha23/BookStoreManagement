using BookStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Provider
{
    public interface IBookProvider
    {
        public List<BookDetails> AllBooks();
        public BookDetails bookDetails(int id);
    }
}
