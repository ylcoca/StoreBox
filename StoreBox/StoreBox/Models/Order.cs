using System;
using System.Collections.Generic;

#nullable disable

namespace StoreBox.Models
{
    public partial class Order
    {
        public Order()
        {
            ProductOrders = new HashSet<ProductOrder>();
        }

        public int OrderId { get; set; }

        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
