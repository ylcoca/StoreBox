using StoreBox.Models;

namespace StoreBox.Service
{
    public interface IOrderService
    {
        public void SaveOrder(Order order);
        public OrderDTO GetOrder(int Id);
    }
}
