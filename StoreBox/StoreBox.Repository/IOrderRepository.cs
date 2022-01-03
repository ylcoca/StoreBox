using StoreBox.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreBox.Repository
{
    public interface IOrderRepository
    {
        public Task<int> SaveOrderAsync(Order order);
        public Task<IEnumerable<ProductType>> GetOrderProductTypes(int Id);
    }
}
