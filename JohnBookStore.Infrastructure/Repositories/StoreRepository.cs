using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JohnBookStore.Infrastructure.IRepositories.Base;
using JohnBookStore.Core.Models;
using JohnBookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Data.SqlClient;
using JohnBookStore.Infrastructure.Entities;
using JohnBookStore.Infrastructure.IRepositories;
using System.Data;

namespace JohnBookStore.Infrastructure.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        protected readonly JohnBookStoreContext _johnBookStoreContext;

        public StoreRepository(JohnBookStoreContext johnBookStoreContext)
        {
            _johnBookStoreContext = johnBookStoreContext;
        }

        public IEnumerable<AvailableBooks> GetAvailableBooks()
        {
            
            var dbContext = new JohnBookStoreContext(); 
            var availableBooks = new List<AvailableBooks>();

            using (var cmd = dbContext.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = "EXEC dbo.GetBooksAvailibilityInStocks";
                dbContext.Database.OpenConnection();
                using(var result = cmd.ExecuteReader())
                {
                    while (result.Read())
                    {
                        var AvailableBooksModel = new AvailableBooks
                        {
                            ISBN = result.GetString(result.GetOrdinal("ISBN")),
                            BookName = result.GetString(result.GetOrdinal("BookName")),
                            Author = result.GetString(result.GetOrdinal("Author")),
                            MinPrice = result.GetInt32(result.GetOrdinal("MinPrice")).ToString(),
                            MaxPrice = result.GetInt32(result.GetOrdinal("MaxPrice")).ToString(),
                            LeftInStock = result.GetInt32(result.GetOrdinal("leftInStock")).ToString()
                        };
                        availableBooks.Add(AvailableBooksModel);
                    }
                }
            }
            return availableBooks;
        }

        public IEnumerable<AvailableBooks> SearchBook(string bookname)
        {
            var dbContext = new JohnBookStoreContext();
            var availableBooks = new List<AvailableBooks>();
            using (var cmd = dbContext.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = "EXEC dbo.GetBooksAvailibilityInStocks @bookname='" + bookname + "'";
                dbContext.Database.OpenConnection();
                using (var result = cmd.ExecuteReader())
                {
                    while (result.Read())
                    {
                        var AvailableBooksModel = new AvailableBooks
                        {
                            ISBN = result.GetString(result.GetOrdinal("ISBN")),
                            BookName = result.GetString(result.GetOrdinal("BookName")),
                            Author = result.GetString(result.GetOrdinal("Author")),
                            MinPrice = result.GetInt32(result.GetOrdinal("MinPrice")).ToString(),
                            MaxPrice = result.GetInt32(result.GetOrdinal("MaxPrice")).ToString(),
                            LeftInStock = result.GetInt32(result.GetOrdinal("leftInStock")).ToString()
                        };
                        availableBooks.Add(AvailableBooksModel);
                    }
                }
            }
            return availableBooks;
        }

        public BookDetails GetBookDetails(string bookname)
        {
            var dbContext = new JohnBookStoreContext();
            var bookDetails = new BookDetails();
            using (var cmd = dbContext.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = "EXEC dbo.GetBookDetails @bookname='" + bookname + "'";
                dbContext.Database.OpenConnection();
                using (var result = cmd.ExecuteReader())
                {
                    while (result.Read())
                    {
                        var bookModel = new BookDetails
                        {
                            ISBN = result.GetString(result.GetOrdinal("ISBN")),
                            BookName = result.GetString(result.GetOrdinal("BookName")),
                            Author = result.GetString(result.GetOrdinal("Author")),
                            
                        };
                        bookModel.bookAvailibilityPerStores = BookAvailibilityPerStore(bookModel.ISBN).ToList();
                        bookDetails = bookModel;
                    }                    
                }
            }
            return bookDetails;
        }

        public List<BookAvailibilityPerStore> BookAvailibilityPerStore(string ISBN)
        {
            var dbContext = new JohnBookStoreContext();
            var bookAvailibilityPerStoreList = new List<BookAvailibilityPerStore>();
            using (var cmd = dbContext.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = "EXEC dbo.GetBookAvailibilityPerStore @ISBN='" + ISBN +"'" ;
                dbContext.Database.OpenConnection();
                using (var result = cmd.ExecuteReader())
                {
                    while (result.Read())
                    {
                        var AvailableModel = new BookAvailibilityPerStore
                        {
                            StoreID = result.GetInt32(result.GetOrdinal("StoreID")).ToString(),
                            StoreName = result.GetString(result.GetOrdinal("Storename")),
                            Price = result.GetDecimal(result.GetOrdinal("Price")).ToString(),
                            InStock = result.GetInt32(result.GetOrdinal("InStock")).ToString()

                        };
                        bookAvailibilityPerStoreList.Add(AvailableModel);
                    }                   
                }
            }
            return bookAvailibilityPerStoreList;
        }
    }
}
