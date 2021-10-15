using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JohnBookStore.Api.Models
{
    public class BookAvailibilityPerStore
    {
        public int StoreID { get; set; }
        public string StoreName { get; set; }
        public string Price { get; set; }
        public int InStock { get; set; }

    }
}
