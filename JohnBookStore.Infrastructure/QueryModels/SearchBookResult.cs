using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBookStore.Infrastructure.QueryModels
{
    public class SearchBookResult
    {
        public string ISBN { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string MinPrice { get; set; }
        public string MaxPrice { get; set; }
        public string LeftInStock { get; set; }
    }
}
