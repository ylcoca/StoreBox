using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using StoreBox.Entities.Models;
using System;
using System.Linq;

namespace StoreBox.Entities
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedDataProductTypes(serviceScope.ServiceProvider.GetService<StoreBoxDBContext>());
                SeedDataOrders(serviceScope.ServiceProvider.GetService<StoreBoxDBContext>());
                SeedDataProductOrder(serviceScope.ServiceProvider.GetService<StoreBoxDBContext>());
            }
        }

        private static void SeedDataProductOrder(StoreBoxDBContext context)
        {
            if (context.ProductOrders == null || !context.ProductOrders.Any())
            {
                Console.WriteLine("--> Seeding Product Orders data");
                context.ProductOrders.AddRange(
                    new ProductOrder() { ProductOrderId = 1, OrderId = 10, ProductTypeID = 1 },
                    new ProductOrder() { ProductOrderId = 2, OrderId = 10, ProductTypeID = 4 },
                    new ProductOrder() { ProductOrderId = 3, OrderId = 11, ProductTypeID = 1 },
                    new ProductOrder() { ProductOrderId = 4, OrderId = 11, ProductTypeID = 3 },
                    new ProductOrder() { ProductOrderId = 5, OrderId = 11, ProductTypeID = 3 },
                    new ProductOrder() { ProductOrderId = 6, OrderId = 11, ProductTypeID = 6 },
                    new ProductOrder() { ProductOrderId = 7, OrderId = 12, ProductTypeID = 1 },
                    new ProductOrder() { ProductOrderId = 8, OrderId = 12, ProductTypeID = 3 },
                    new ProductOrder() { ProductOrderId = 9, OrderId = 12, ProductTypeID = 3 },
                    new ProductOrder() { ProductOrderId = 10, OrderId = 12, ProductTypeID = 6 },
                    new ProductOrder() { ProductOrderId = 11, OrderId = 12, ProductTypeID = 6 },
                    new ProductOrder() { ProductOrderId = 12, OrderId = 13, ProductTypeID = 1 },
                    new ProductOrder() { ProductOrderId = 13, OrderId = 13, ProductTypeID = 3 },
                    new ProductOrder() { ProductOrderId = 14, OrderId = 13, ProductTypeID = 3 },
                    new ProductOrder() { ProductOrderId = 15, OrderId = 13, ProductTypeID = 6 },
                    new ProductOrder() { ProductOrderId = 16, OrderId = 13, ProductTypeID = 6 },
                    new ProductOrder() { ProductOrderId = 17, OrderId = 13, ProductTypeID = 6 },
                    new ProductOrder() { ProductOrderId = 18, OrderId = 13, ProductTypeID = 6 },
                    new ProductOrder() { ProductOrderId = 19, OrderId = 13, ProductTypeID = 6 }
                    );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have Order");
            }
        }

        private static void SeedDataOrders(StoreBoxDBContext context)
        {
            if (context.Orders == null || !context.Orders.Any())
            {
                Console.WriteLine("--> Seeding Order data");
                context.Orders.AddRange(
                    new Order() { OrderId = 10 },
                    new Order() { OrderId = 11 },
                    new Order() { OrderId = 12 },
                    new Order() { OrderId = 13 }
                    );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have Order");
            }
        }

        private static void SeedDataProductTypes(StoreBoxDBContext context)
        {
            if (context.ProductTypes == null || !context.ProductTypes.Any())
            {
                Console.WriteLine("--> Seeding Product Type data");
                context.ProductTypes.AddRange(
                    new ProductType() { ProductTypeID = 1, ProductTypeName = "photoBook", Width = 19, Symbol = "0" },
                    new ProductType() { ProductTypeID = 3, ProductTypeName = "calendar", Width = 10, Symbol = "|" },
                    new ProductType() { ProductTypeID = 4, ProductTypeName = "canvas", Width = 16, Symbol = "/" },
                    new ProductType() { ProductTypeID = 5, ProductTypeName = "cards", Width = 4.7F, Symbol = "\\" },
                    new ProductType() { ProductTypeID = 6, ProductTypeName = "mug", Width = 94, Symbol = "." }
                    );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have Product Types");
            }
        }
    }
}
