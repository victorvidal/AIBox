using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Entities;
using LibraryManagement.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // GET: api/book
        [HttpGet(Name = "GetBooks")]
        public List<Book> Get()
        {
            List<Book> Books = _bookRepository.GetBooks();
            return Books;
        }

        // GET: api/book/{id}
        [HttpGet("{id}", Name = "GetBook")]
        public Book Get(int id)
        {
            return _bookRepository.Get(id);
        }

        // POST: api/book
        [HttpPost(Name = "AddBook")]
        public void Post([FromBody] Book book)
        {
            _bookRepository.Add(book);
        }

        [HttpPut("{id}", Name = "EditBook")]
        public int Edit([FromBody] Book book)
        {
            return _bookRepository.Edit(book);
        }

        // DELETE: api/book/{id}
        [HttpDelete("{id}", Name = "DeleteBook")]
        public int Delete(int id)
        {
            return _bookRepository.Delete(id);
        }
    }
}