using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JohnBookStore.Infrastructure.Entities;
using JohnBookStore.Application.Interfaces;
using JohnBookStore.Infrastructure.IRepositories;
using JohnBookStore.Infrastructure.Repositories;
using JohnBookStore.Infrastructure.Data;

namespace JohnBookStore.Application.Services
{
    public class StoreService : IStoreService
    {
        StoreRepository _storeRepository;
        JohnBookStoreContext _johnBookStoreContext;
        public StoreService()
        {
            _johnBookStoreContext = new JohnBookStoreContext();
            _storeRepository = new StoreRepository(_johnBookStoreContext);
        }

      

        public IEnumerable<AvailableBooks> GetAvailableBooks()
        {
            return _storeRepository.GetAvailableBooks();
        }

        public BookDetails GetBookDetails(string bookname)
        {
            return _storeRepository.GetBookDetails(bookname);
        }

        public IEnumerable<AvailableBooks> SearchBook(string searchText)
        {
            return _storeRepository.SearchBook(searchText);
        }
    }
}
