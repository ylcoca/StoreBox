﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace StoreBox.Entities.Models
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