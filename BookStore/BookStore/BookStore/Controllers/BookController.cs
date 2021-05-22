using BookStore.Model;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IBookRepository _bookRepository;
        
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        
        [HttpGet]
        public IActionResult AllBooks()
        {
            _bookRepository = new BookRepository();
            return Ok(_bookRepository.GetAllBooks());
        }

            [HttpGet]
        [Route("getbookdetails")]
        public IActionResult GetBookdetailss(int id)
        {
            _bookRepository = new BookRepository();
            return Ok(_bookRepository.GetBookDetails(id));
        }

        [HttpPost]
        public bool Post(BookDetails bookDetails)
        {
            return _bookRepository.AddBook(bookDetails);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
