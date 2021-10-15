using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBookStore.Infrastructure.Entities
{
    public class BookDetails
    {
        public string ISBN { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public List<BookAvailibilityPerStore> bookAvailibilityPerStores { get; set; }
    }

    public class BookAvailibilityPerStore
    {
        public string StoreID { get; set; }
        public string StoreName { get; set; }
        public string Price { get; set; }
        public string InStock { get; set; }
    }
}