using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreBox.Entities
{
    public class Order
    {
        public int OrderId { get; set; }

        public ICollection<ProductType> Students { get; set; }
    }
}
