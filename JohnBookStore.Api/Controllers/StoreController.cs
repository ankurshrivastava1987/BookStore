using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Web;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using JohnBookStore.Api.Models;
using System.Threading.Tasks;
using JohnBookStore.Application.Interfaces;
using JohnBookStore.Infrastructure.Entities;
using Newtonsoft.Json;
using JohnBookStore.Application.Services;
using System.IO;
using Microsoft.AspNetCore.Http;


namespace JohnBookStore.Api.Controllers
{
    [Route("api/store")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;
        private readonly ILogger<StoreController> _logger;

        public StoreController(IStoreService storeService,ILogger<StoreController> logger)
        {
            _storeService = storeService;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAvailableBooks")]
        public IEnumerable<VM_AvailableBooks> GetAvailableBooks()
        {
            List<VM_AvailableBooks> availableBooks = new List<VM_AvailableBooks>();
            List<AvailableBooks> books = _storeService.GetAvailableBooks().ToList();
            foreach(AvailableBooks book in books)
            {
                VM_AvailableBooks vmBook = new VM_AvailableBooks();
                vmBook.ISBN = book.ISBN;
                vmBook.Author = book.Author;
                vmBook.BookName = book.BookName;
                vmBook.PriceRange = book.MinPrice + "-" + book.MaxPrice;
                vmBook.LeftInStock = book.LeftInStock;
                availableBooks.Add(vmBook);
            }
            return availableBooks;
        }

        [HttpGet]
        [Route("GetBookDetails")]
        public BookDetails GetBookDetails(string bookname)
        {
           
            BookDetails bookDetails = new BookDetails();
            bookDetails = _storeService.GetBookDetails(bookname);
            return bookDetails;
        }

        [HttpGet]
        [Route("SearchBook")]
        public IEnumerable<VM_AvailableBooks> SearchBook(string searchText)
        {
            List<VM_AvailableBooks> availableBooks = new List<VM_AvailableBooks>();
            List<AvailableBooks> books = _storeService.SearchBook(searchText).ToList();
            foreach (AvailableBooks book in books)
            {
                VM_AvailableBooks vmBook = new VM_AvailableBooks();
                vmBook.ISBN = book.ISBN;
                vmBook.Author = book.Author;
                vmBook.BookName = book.BookName;
                vmBook.PriceRange = book.MinPrice + "-" + book.MaxPrice;
                vmBook.LeftInStock = book.LeftInStock;
                availableBooks.Add(vmBook);
            }
            return availableBooks;
            
        }

        [HttpGet]
        [Route("OrderBook")]
        public string OrderBook(string StoreID, string ISBN, string ContactEmail)
        {
            string OrderDirectory = @"C:\BookOrder\";
            string fileName = OrderDirectory + "JohnBookStore_" + StoreID + "_" + ISBN + "_" + DateTime.Now.ToShortDateString() + ".txt";

            bool exists = System.IO.Directory.Exists(OrderDirectory);

            if (!exists)
                System.IO.Directory.CreateDirectory(OrderDirectory);

            if (!System.IO.File.Exists(fileName))
            {
                using (StreamWriter sw = System.IO.File.CreateText(fileName))
                {
                   
                    sw.WriteLine("StoreID : {0}", StoreID);
                    sw.WriteLine("ISBN : {0}", ISBN);
                    sw.WriteLine("ContactEmail : {0}", ContactEmail);
                   
                }             
            }
           
            return "Success";
        }
    }
}
