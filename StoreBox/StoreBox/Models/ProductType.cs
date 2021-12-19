using System;
using System.Collections.Generic;

#nullable disable

namespace StoreBox.Models
{
    public partial class ProductType
    {
        public ProductType()
        {
            ProductOrders = new HashSet<ProductOrder>();
        }

        public int ProductTypeID { get; set; }
        public string ProductTypeName { get; set; }
        public float Width { get; set; }
        public string Symbol { get; set; }

        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
