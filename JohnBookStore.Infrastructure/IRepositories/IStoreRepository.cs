using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JohnBookStore.Infrastructure.Entities;
using JohnBookStore.Infrastructure.Data;

namespace JohnBookStore.Infrastructure.IRepositories
{
    public interface IStoreRepository
    {
         IEnumerable<AvailableBooks> GetAvailableBooks();
         IEnumerable<AvailableBooks> SearchBook(string bookname);
         BookDetails GetBookDetails(string bookname);
        
    }
}
