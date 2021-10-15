using System;
using System.Collections.Generic;

#nullable disable

namespace JohnBookStore.Infrastructure.Entities
{
    public partial class Store
    {
        public Store()
        {
            StockDetails = new HashSet<StockDetail>();
        }

        public int StoreId { get; set; }
        public string Storename { get; set; }

        public virtual ICollection<StockDetail> StockDetails { get; set; }
    }
}
