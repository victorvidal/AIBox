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
    public class UserRepository : IUserRepository
    {
        IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("LibraryConnection").Value;
            return connection;
        }

        public int Add(User user)
        {
            var connectionString = this.GetConnection();
            int count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "INSERT INTO Users(Id, Name, Phone, Address) VALUES (@Id, @Name, @Phone, @Address); SELECT CAST(SCOPE_IDENTITY() as INT);";
                    count = con.Execute(query, user);
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
                    var query = "DELETE FROM Users WHERE Id =" + id;
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

        public int Edit(User user)
        {
            var connectionString = this.GetConnection();
            var count = 0;

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "UPDATE Users SET Name = @Name, Phone = @Phone, Address = @Address WHERE Id = " + user.Id;
                    count = con.Execute(query, user);
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

        public User Get(int id)
        {
            var connectionString = this.GetConnection();
            User user = new User();

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Users WHERE Id =" + id;
                    user = con.Query<User>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
                return user;
            }

        }

        public List<User> GetUsers()
        {
            var connectionString = this.GetConnection();
            List<User> users = new List<User>();

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Users";
                    users = con.Query<User>(query).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
                return users;
            }
        }
    }
}