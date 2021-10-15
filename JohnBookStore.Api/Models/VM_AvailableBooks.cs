using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace JohnBookStore.Api.Models
{
    public class VM_AvailableBooks
    {
        public string ISBN { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string PriceRange { get; set; }
        public string LeftInStock { get; set; }
    }
}
