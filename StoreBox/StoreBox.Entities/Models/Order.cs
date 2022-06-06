using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace StoreBox.Entities.Models
{
    [Table("order")]
    public class Order
    {
        public Order()
        {
            ProductOrders = new HashSet<ProductOrder>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("order_id")]
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Product Orders are required")]
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
