using System;
using System.Collections.Generic;

namespace Candle.DATA.EF.Models
{
    public partial class ProductOrder
    {
        public int ProductOrderId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal PurchasePrice { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
