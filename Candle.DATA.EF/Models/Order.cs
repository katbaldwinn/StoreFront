using System;
using System.Collections.Generic;

namespace Candle.DATA.EF.Models
{
    public partial class Order
    {
        public Order()
        {
            ProductOrders = new HashSet<ProductOrder>();
        }

        public int OrderId { get; set; }
        public string UserId { get; set; } = null!;
        public bool IsDelivery { get; set; }
        public DateTime OrderPlaced { get; set; }

        public virtual UserDetail User { get; set; } = null!;
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
