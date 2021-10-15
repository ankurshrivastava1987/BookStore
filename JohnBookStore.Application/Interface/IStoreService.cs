using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JohnBookStore.Infrastructure.Entities;

namespace JohnBookStore.Application.Interfaces
{
    public interface IStoreService
    {
         IEnumerable<AvailableBooks> GetAvailableBooks();
         IEnumerable<AvailableBooks> SearchBook(string bookname);
         BookDetails GetBookDetails(string bookname);
        
    }
}
