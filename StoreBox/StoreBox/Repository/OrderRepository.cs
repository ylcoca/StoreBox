using Microsoft.EntityFrameworkCore;
using StoreBox.Models;
using System.Collections.Generic;
using System.Linq;

namespace StoreBox.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreBoxDBContext context;
        public OrderRepository(StoreBoxDBContext dbcontex)
        {
            context = dbcontex;
        }

        public IEnumerable<ProductType> GetOrderProductTypes(int Id)
        {
            IEnumerable<ProductType> cartItems = null;
            var cartIncludingItems = context.Orders.Include(order => order.ProductOrders).ThenInclude(productType => productType.ProductType)
                .FirstOrDefault(order => order.OrderId == Id);

            if (cartIncludingItems != null)
            {
                cartItems = cartIncludingItems.ProductOrders.Select(row => row.ProductType);
            }
            return cartItems;
        }

        public int SaveOrder(Order order)
        {
            int id = 0;

            foreach (var item in order.ProductOrders)
            {

                var producType = GetProductType(item);
                var productOrders = new ProductOrder
                {
                    ProductType = producType                    
                };

                if (id == 0)
                {
                    productOrders.Order = new Order();
                }
                else
                {
                    productOrders.OrderId = id;
                }

                context.Add(productOrders);
                context.SaveChanges();
                id = productOrders.OrderId;
            }

            return id;

        }

        private ProductType GetProductType(ProductOrder item)
        {
            return context.ProductTypes.First(i => i.Symbol == item.ProductType.Symbol);
        }
    }
}
