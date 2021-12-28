using StoreBox.Entities.Models;
using System.Collections.Generic;

namespace StoreBox.Repository
{
    public interface IOrderRepository
    {
        public int SaveOrder(Order order);
        public IEnumerable<ProductType> GetOrderProductTypes(int Id);
    }
}
