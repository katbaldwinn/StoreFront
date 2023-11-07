using System;
using System.Collections.Generic;

namespace Candle.DATA.EF.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductOrders = new HashSet<ProductOrder>();
        }

        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductName { get; set; } = null!;
        public string? ProductDescription { get; set; }
        public int StatusId { get; set; }
        public string? ProductImage { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual StockStatus Status { get; set; } = null!;
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
