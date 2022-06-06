using Microsoft.EntityFrameworkCore;
using StoreBox.Entities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreBox.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreBoxDBContext _context;
        public OrderRepository(StoreBoxDBContext dbcontex)
        {
            _context = dbcontex;
        }

        private async Task<Order> LookupOrderById(int Id)
        {
            return await _context.Orders.Where(o => o.OrderId == Id).Include(p=>p.ProductOrders).FirstOrDefaultAsync();
        }

        public async Task<int> DeleteOrder(int Id)
        {
          var order = await LookupOrderById(Id);
          _context.Orders.Remove(order);
          await _context.SaveChangesAsync();

          return Id;
        }

        public async Task<IEnumerable<ProductType>> GetOrderProductTypes(int Id)
        {
                IEnumerable<ProductType> cartItems = null;
                var cartIncludingItems = await _context.Orders
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

                _context.Add(productOrders);
                await _context.SaveChangesAsync();
                id = productOrders.OrderId;
            }

            return id;
        }

        public async Task<ProductType> GetProductType(ProductOrder item)
        {
            return await _context.ProductTypes.FirstOrDefaultAsync(i => i.Symbol == item.ProductType.Symbol);
        }
    }
}
