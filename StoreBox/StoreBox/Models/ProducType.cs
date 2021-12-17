using System;
using System.Collections.Generic;

#nullable disable

namespace StoreBox.Models
{
    public partial class ProducType
    {
        public ProducType()
        {
            ProductOrders = new HashSet<ProductOrder>();
        }

        public int ProductTypeID { get; set; }
        public string ProductTypeName { get; set; }
        public float Width { get; set; }

        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
