using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StoreBox.Config;
using StoreBox.Entities.Models;
using StoreBox.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreBox.Service.Tests
{

    [TestClass()]
    public class OrderServiceTests
    {

        private IOrderService _service;
        Mock<IOrderRepository> _repoMock;
        StoreBoxConfiguration _config;
        List<ProductType> _productList;

        [TestInitialize]
        public void Initialize()
        {
            //Arrange
            _repoMock = new Mock<IOrderRepository>();
            _config = new StoreBoxConfiguration();

            _service = new OrderService(_repoMock.Object, _config);

            _productList = new List<ProductType>
            {
                new ProductType
                {
                    Symbol = "0",
                    Width = 19,
                    ProductTypeName = "photoBook"
                },
                new ProductType
                {
                    Symbol = "|",
                    Width = 10,
                    ProductTypeName = "calendar"
                }
            };

            _repoMock.Setup(r => r.GetOrderProductTypes(It.IsAny<int>())).ReturnsAsync(_productList);
        }

        [TestMethod()]
        public async Task GetOrder_WhenCalled_ReturnsOrderDTO()
        {
            var result = await _service.GetOrder(It.IsAny<int>());

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OrderDto));
            Assert.AreEqual(29, result.TotalSize);
        }

        [TestMethod()]
        public async Task GetOrder_IdNotFound_ReturnsNull()
        {
            _repoMock.Setup(r => r.GetOrderProductTypes(It.IsAny<int>())).ReturnsAsync((IEnumerable<ProductType>)null);

            var result = await _service.GetOrder(It.IsAny<int>());
            Assert.IsNull(result);
        }

        [TestMethod()]
        public async Task SaveOrder_WhenCalled_ReturnsMinWidth()
        {
            var result = await _service.GetOrder(It.IsAny<int>());
            Assert.AreEqual(29, result.TotalSize);
        }
    }
}