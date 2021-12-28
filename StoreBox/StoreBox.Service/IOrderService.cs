using StoreBox.Entities.Models;

namespace StoreBox.Service
{
    public interface IOrderService
    {
        public float SaveOrder(Order order);
        public OrderDTO GetOrder(int Id);
    }
}
