using System;
using System.Collections.Generic;

namespace Candle.DATA.EF.Models
{
    public partial class StockStatus
    {
        public StockStatus()
        {
            Products = new HashSet<Product>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
