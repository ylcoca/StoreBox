using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace StoreBox.Entities.Models
{
    public partial class ProductType
    {
        public ProductType()
        {
            ProductOrders = new HashSet<ProductOrder>();
        }

        public int ProductTypeID { get; set; }
        [Required]
        public string ProductTypeName { get; set; }
        [Required]
        public float Width { get; set; }
        [Required]
        public string Symbol { get; set; }

        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
