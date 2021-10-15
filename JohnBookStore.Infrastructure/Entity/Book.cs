using System;
using System.Collections.Generic;

#nullable disable

namespace JohnBookStore.Infrastructure.Entities
{ 
    public partial class Book
    {
        public Book()
        {
            Orders = new HashSet<Order>();
        }

        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Isbn { get; set; }
        public string Author { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }


}
