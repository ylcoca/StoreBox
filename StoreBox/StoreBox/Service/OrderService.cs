using StoreBox.Models;
using StoreBox.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreBox.Service
{
    public class OrderService : IOrderService
    {
        IOrderRepository _repository;
        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }
        public OrderDTO GetOrder(int Id)
        {
            var products  = _repository.GetOrderProductTypes(Id);
            var dto = new OrderDTO { 
                TotalSize = TotalSize(products)
            };

            return dto;
        }

        public void SaveOrder(Order order)
        {
            _repository.SaveOrder(order);
        }

        private float TotalSize(IEnumerable<ProducType> products)
        {
            //calculate for cups ...

            float totalSize = 0;
            foreach (var product in products)
            {
                totalSize += product.Width;
            }
            return totalSize;
        }
    }
}
