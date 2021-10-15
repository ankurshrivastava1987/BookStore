using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JohnBookStore.Core.Models
{
    public class BookDetail
    {
        public string ISBN { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public List<BookAvailibilityInStore> BookAvailibilityInStores { get; set; }
       

    }
}
