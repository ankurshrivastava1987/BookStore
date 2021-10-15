using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JohnBookStore.Core.Models
{
    public class BookAvailibilityInStore
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string Price { get; set; }
        public int InStock { get; set; }

    }
}
