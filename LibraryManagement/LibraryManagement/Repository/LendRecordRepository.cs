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
    public class LendRecordRepository : ILendRecordRepository
    {
        IConfiguration _configuration;

        public LendRecordRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("LibraryConnection").Value;
            return connection;
        }

        public int Add(LendRecord lendRecord)
        {
            var connectionString = this.GetConnection();
            int count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "INSERT INTO LendRecord(IdLend, IdUser, IdBook, LendDate) VALUES (@IdLend, @IdUser, @IdBook, @LendDate); SELECT CAST(SCOPE_IDENTITY() as INT);";
                    count = con.Execute(query, lendRecord);

                    query = "UPDATE Book SET Amount = (Amount - 1) WHERE IdBook = " + lendRecord.IdBook;
                    count = con.Execute(query, lendRecord);
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

                    var query = "UPDATE Book SET Amount = (Amount + 1) WHERE IdBook = (SELECT IdBook FROM LendRecord WHERE IdLend = " + id + ")" ;
                    count = con.Execute(query);

                    query = "DELETE FROM LendRecord WHERE IdLend =" + id;
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

        public int Edit(LendRecord lendRecord)
        {
            var connectionString = this.GetConnection();
            var count = 0;

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "UPDATE LendRecord SET IdUser = @IdUser, IdBook = @IdBook, LendDate = @LendDate WHERE IdLend = " + lendRecord.IdLend;
                    count = con.Execute(query, lendRecord);
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

        public LendRecord Get(int id)
        {
            var connectionString = this.GetConnection();
            LendRecord lendRecord = new LendRecord();

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM LendRecord WHERE IdLend =" + id;
                    lendRecord = con.Query<LendRecord>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
                return lendRecord;
            }

        }

        public List<LendRecord> GetLendRecords()
        {
            var connectionString = this.GetConnection();
            List<LendRecord> lendRecords = new List<LendRecord>();

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM LendRecord";
                    lendRecords = con.Query<LendRecord>(query).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
                return lendRecords;
            }
        }
    }
}