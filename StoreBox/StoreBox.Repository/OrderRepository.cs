using Microsoft.EntityFrameworkCore;
using StoreBox.Entities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreBox.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreBoxDBContext context;
        public OrderRepository(StoreBoxDBContext dbcontex)
        {
            context = dbcontex;
        }

        public async Task<IEnumerable<ProductType>> GetOrderProductTypes(int Id)
        {
                IEnumerable<ProductType> cartItems = null;
                var cartIncludingItems = await context.Orders
                 .Include(order => order.ProductOrders)
                .ThenInclude(productType => productType.ProductType)
                .FirstOrDefaultAsync(order => order.OrderId == Id);

                if (cartIncludingItems != null)
                {
                    cartItems = cartIncludingItems.ProductOrders.Select(row => row.ProductType);
                }
                return cartItems;            
        }

        public async Task<int> SaveOrderAsync(Order order)
        {
            int id = 0;

            foreach (var item in order.ProductOrders)
            {

                var producType = await GetProductType(item);
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

        private async Task<ProductType> GetProductType(ProductOrder item)
        {
            return await context.ProductTypes.FirstOrDefaultAsync(i => i.Symbol == item.ProductType.Symbol);
        }
    }
}
