using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JohnBookStore.Api.Models
{
    public class VM_BookOrder
    {
        public int StoreID { get; set; }
        public string ISBN { get; set; }
        public string ContactEmail { get; set; }

    }
}
