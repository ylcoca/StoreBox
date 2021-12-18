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

        public IEnumerable<ProducType> GetOrderProductTypes(int Id)
        {
            var cartIncludingItems = context.Orders.Include(cart => cart.ProductOrders).ThenInclude(row => row.ProductType)
                .First(cart => cart.OrderId == Id);
            var cartItems = cartIncludingItems.ProductOrders.Select(row => row.ProductType);


            return cartItems;
        }

        public int SaveOrder(Order order)
        {
            int id = 0;

            foreach (var item in order.ProductOrders)
            {
                var producType = context.ProducTypes.First(i => i.ProductTypeID == item.ProductType.ProductTypeID);
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
    }
}
