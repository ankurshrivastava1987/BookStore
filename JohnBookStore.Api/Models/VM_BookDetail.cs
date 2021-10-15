using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JohnBookStore.Api.Models;

namespace JohnBookStore.Api.Models
{
    public class VM_BookDetail
    {
        public string ISBN { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public List<BookAvailibilityPerStore> BookAvailibilityInStores { get; set; }
       

    }
}
