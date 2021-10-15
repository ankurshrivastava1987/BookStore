using System;
using System.Collections.Generic;

#nullable disable

namespace JohnBookStore.Infrastructure.Entities
{
    public partial class StockDetail
    {
        public int StockId { get; set; }
        public int BookId { get; set; }
        public decimal Price { get; set; }
        public int? InStock { get; set; }
        public int StoreId { get; set; }

        public virtual Store Store { get; set; }
    }
}
