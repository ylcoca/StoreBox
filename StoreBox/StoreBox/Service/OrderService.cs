using StoreBox.Models;
using StoreBox.Repository;
using System.Collections.Generic;

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
            var productList = new List<ProducTypeDTO>();

            foreach (var product in products)
            {
                productList.Add(new ProducTypeDTO {
                    ProductTypeName = product.ProductTypeName,
                    Width = product.Width
                });
            }

            var dto = new OrderDTO {
                TotalSize = TotalSize(products),
                Products = productList
            };

            return dto;
        }

        public float SaveOrder(Order order)
        {
            var Id = _repository.SaveOrder(order);

            return GetOrder(Id).TotalSize;
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
