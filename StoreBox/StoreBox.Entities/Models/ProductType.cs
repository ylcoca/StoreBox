using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace StoreBox.Entities.Models
{
    [Table("product_type")]
    public class ProductType
    {
        
        public ProductType()
        {
            ProductOrders = new HashSet<ProductOrder>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("product_type_id")]
        public int ProductTypeID { get; set; }
        [Required(ErrorMessage = "Name is required")]        
        [Column("product_type_name")]
        public string ProductTypeName { get; set; }
        [Required(ErrorMessage = "width is required")]
        [Column("width")]
        public float Width { get; set; }
        [Required(ErrorMessage = "symbol is required")]
        [Column("symbol")]
        public string Symbol { get; set; }

        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
