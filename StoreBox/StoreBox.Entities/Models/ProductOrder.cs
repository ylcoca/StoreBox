using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace StoreBox.Entities.Models
{
    [Table("product_order")]
    public class ProductOrder
    {        
        [Column("product_order_id")]
        public int ProductOrderId { get; set; }
        [Column("order_id")]
        public int OrderId { get; set; }
        [Column("product_type_id")]
        public int ProductTypeID { get; set; }

        public virtual Order Order { get; set; }
        public virtual ProductType ProductType { get; set; }
    }
}
