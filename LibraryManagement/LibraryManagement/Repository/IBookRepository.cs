using LibraryManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Repository
{
    public interface IBookRepository
    {
        int Add(Book book);
        List<Book> GetBooks();
        Book Get(int id);
        int Edit(Book book);
        int Delete(int id);

    }
}