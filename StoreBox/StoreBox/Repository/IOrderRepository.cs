using StoreBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreBox.Repository
{
    public interface IOrderRepository
    {
        public int SaveOrder(Order order);
        public IEnumerable<ProductType> GetOrderProductTypes(int Id);
    }
}
