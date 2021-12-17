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

        public void SaveOrder(Order order)
        {

            var producType = context.ProducTypes.First(i => i.ProductTypeID == 1);
           

            var productOrders = new ProductOrder
            {
                ProductType = producType,
                Order = order
            };

            context.Add(productOrders);
            context.SaveChanges();



        }
    }
}
