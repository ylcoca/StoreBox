using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreBox.Entities.Models
{
    public class OrderDto
    {
        public IEnumerable<ProductTypeDto> Products { get; set; }
        public float TotalSize { get; set; }
    }
}
