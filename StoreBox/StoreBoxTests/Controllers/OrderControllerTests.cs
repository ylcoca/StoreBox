using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StoreBox.Entities.Models;
using StoreBox.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreBox.Controllers.Tests
{
    [TestClass()]
    public class OrderControllerTests
    {
        OrderController _controller;
        Mock<IOrderService> _serviceMock;
        Mock<IMemoryCache> _memoryCacheMock;
        OrderDto _orderDto;
        List<ProductTypeDto> _productList;

        [TestInitialize]
        public void Initialize()
        {
            //Arrange
            _serviceMock = new Mock<IOrderService>();
            _memoryCacheMock = new Mock<IMemoryCache>();

            _controller = new OrderController(_serviceMock.Object, _memoryCacheMock.Object);
        }

        [TestMethod()]
        public async Task GetOrder_IsNull_ReturnNotFound()
        {
            var result = await _controller.GetOrder(0) as ObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual("Id its not valid", result.Value);
        }

        [TestMethod()]
        [DataRow(133)]
        public async Task GetOrder_IsNotNull_ReturnsTotalSize(float expectedResult)
        {
            _productList = new List<ProductTypeDto>();

            _orderDto = new OrderDto
            {
                TotalSize = 133,
                Products = _productList
            };

            _serviceMock.Setup(r => r.GetOrder(11)).ReturnsAsync(_orderDto);

            var result = await _controller.GetOrder(11) as ObjectResult;
            Assert.AreEqual(((OrderDto)result.Value).TotalSize, expectedResult);
        }

        [TestMethod()]
        public async Task AddOrder_ExceptionThrown_StatusCode500()
        {
            Order order = new();

            _serviceMock.Setup(r => r.SaveOrder(order)).Throws(new Exception());

            var result = await _controller.AddOrder(order);
            Assert.IsNotNull(result);
            Assert.AreEqual(500, ((ObjectResult)result).StatusCode);
        }
        
        [TestMethod()]
        public async Task AddOrder_WhenCalled_ReturnsOK()
        {
            Order order = new();
            _serviceMock.Setup(r => r.SaveOrder(order)).ReturnsAsync(133);
            var result = await _controller.AddOrder(order);

            Assert.IsNotNull(result);
            Assert.AreEqual(200, ((ObjectResult)result).StatusCode);
        }
    }


}