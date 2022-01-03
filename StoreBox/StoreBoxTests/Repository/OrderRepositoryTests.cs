using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StoreBox.Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace StoreBox.Repository.Tests
{
    [TestClass()]
    public class OrderRepositoryTests
    {
        private IOrderRepository _repo;
        private Mock<StoreBoxDBContext> mockContext;
        private Mock<DbSet<Order>> mockSetOrder;
        private Mock<DbSet<ProductOrder>> mockSetProductOrder;
        private Mock<DbSet<ProductType>> mockSetProductType;

        ProductType productType = new ProductType();
        Order order = new Order();
        List<Order> sourceList = new List<Order>();

        [TestInitialize]
        public void Initialize()
        {
            mockSetOrder = new Mock<DbSet<Order>>();
            mockSetProductOrder = new Mock<DbSet<ProductOrder>>();
            mockSetProductType = new Mock<DbSet<ProductType>>();
            mockContext = new Mock<StoreBoxDBContext>();

            InitObjects();           

            var sourceList = new List<Order>
            {
                new Order
                {
                    OrderId = 11,
                    ProductOrders = new List<ProductOrder>
                    {
                        new ProductOrder
                        {
                            OrderId = 11,
                            ProductTypeID = 3,
                            ProductType = new ProductType
                            {
                                Symbol = "|",
                                Width = 10
                            }
                        }
                    }
                }
            }.AsQueryable();

            var data = new List<ProductType>
            {
                new ProductType { Symbol = "0" },
                new ProductType { Symbol = "|" },
                new ProductType { Symbol = "." }
            }.AsQueryable();

            mockSetOrder.As<IQueryable<Order>>().Setup(m => m.Provider).Returns(sourceList.Provider);
            mockSetOrder.As<IQueryable<Order>>().Setup(m => m.Expression).Returns(sourceList.Expression);
            mockSetOrder.As<IQueryable<Order>>().Setup(m => m.ElementType).Returns(sourceList.ElementType);
            mockSetOrder.As<IQueryable<Order>>().Setup(m => m.GetEnumerator()).Returns(() => sourceList.GetEnumerator());


            mockSetProductType.As<IQueryable<ProductType>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSetProductType.As<IQueryable<ProductType>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSetProductType.As<IQueryable<ProductType>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSetProductType.As<IQueryable<ProductType>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            mockContext.Setup(m => m.ProductTypes).Returns(mockSetProductType.Object);
            mockContext.Setup(m => m.ProductOrders).Returns(mockSetProductOrder.Object);

            _repo = new OrderRepository(mockContext.Object);

        }

        private void InitObjects()
        {
            productType = new ProductType
            {
                Symbol = "0"
            };

            order = new Order
            {
                ProductOrders = new List<ProductOrder>
                {
                    new ProductOrder
                    {
                        ProductType = productType
                    }
                }
            };
        }

        [TestMethod()]
        public void SaveOrder_WhenCalled_StoreTheOrder()
        {
            _repo.SaveOrderAsync(order);

            mockContext.Verify(m => m.Add(It.IsAny<ProductOrder>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod()]
        public void GetOrderProductTypes_WhenCalled_ReturnOrder()
        {

            mockContext.Setup(m => m.Orders).Returns(mockSetOrder.Object);

            var result = _repo.GetOrderProductTypes(11);

            Assert.IsNotNull(result);
           /* Assert.IsTrue(result.Any(f => f.Symbol == "|"));
            Assert.IsTrue(result.Any(f => f.Width == 10));*/
        }
    }
}