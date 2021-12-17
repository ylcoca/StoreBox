using System;
using System.Collections.Generic;

#nullable disable

namespace StoreBox.Models
{
    public partial class ProductOrder
    {
        public int OrderId { get; set; }
        public int ProductTypeID { get; set; }

        public virtual Order Order { get; set; }
        public virtual ProducType ProductType { get; set; }
    }
}
