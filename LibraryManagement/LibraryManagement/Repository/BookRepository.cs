using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using LibraryManagement.Entities;
using Microsoft.Extensions.Configuration;

namespace LibraryManagement.Repository
{
    public class BookRepository : IBookRepository
    {
        IConfiguration _configuration;

        public BookRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("LibraryConnection").Value;
            return connection;
        }

        public int Add(Book book)
        {
            var connectionString = this.GetConnection();
            int count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "INSERT INTO Book(IdBook, Title, Author, Amount) VALUES (@IdBook, @Title, @Author, @Amount); SELECT CAST(SCOPE_IDENTITY() as INT);";
                    count = con.Execute(query, book);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }

        public int Delete(int id)
        {
            var connectionString = this.GetConnection();
            var count = 0;

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "DELETE FROM Book WHERE IdBook =" + id;
                    count = con.Execute(query);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }

        public int Edit(Book book)
        {
            var connectionString = this.GetConnection();
            var count = 0;

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "UPDATE Book SET Title = @Title, Author = @Author, Amount = @Amount WHERE IdBook = " + book.IdBook;
                    count = con.Execute(query, book);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }

        public Book Get(int id)
        {
            var connectionString = this.GetConnection();
            Book book = new Book();

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Book WHERE IdBook =" + id;
                    book = con.Query<Book>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
                return book;
            }

        }

        public List<Book> GetBooks()
        {
            var connectionString = this.GetConnection();
            List<Book> books = new List<Book>();

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Book";
                    books = con.Query<Book>(query).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
                return books;
            }
        }
    }
}