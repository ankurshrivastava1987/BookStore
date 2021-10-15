using System;
using System.Collections.Generic;

#nullable disable

namespace JohnBookStore.Infrastructure.Entities
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int? BookId { get; set; }
        public string Isbn { get; set; }
        public int? StoreId { get; set; }
        public string ContactEmail { get; set; }

        public virtual Book Book { get; set; }
    }
}
