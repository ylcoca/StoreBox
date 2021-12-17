using StoreBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreBox.Repository
{
    public interface IOrderRepository
    {
        public void SaveOrder(Order order);
        public IEnumerable<ProducType> GetOrderProductTypes(int Id);
    }
}
