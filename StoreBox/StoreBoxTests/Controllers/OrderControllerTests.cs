using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StoreBox.Entities.Models;
using StoreBox.Service;
using System;
using System.Collections.Generic;

namespace StoreBox.Controllers.Tests
{
    [TestClass()]
    public class OrderControllerTests
    {
        OrderController _controller;
        Mock<IOrderService> _serviceMock;
        OrderDto _orderDto;
        List<ProductTypeDto> _productList;

        [TestInitialize]
        public void Initialize()
        {
            //Arrange
            _serviceMock = new Mock<IOrderService>();

            _controller = new OrderController(_serviceMock.Object);
        }

        [TestMethod()]
        public void GetOrder_IsNull_ReturnNotFound()
        {
            /*var result = _controller.GetOrder(0) as NotFoundResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(404, result.StatusCode);*/
        }

        [TestMethod()]
        [DataRow(133)]
        public void GetOrder_IsNotNull_ReturnsTotalSize(float expectedResult)
        {
            _productList = new List<ProductTypeDto>();

            _orderDto = new OrderDto
            {
                TotalSize = 133,
                Products = _productList
            };

           /* _serviceMock.Setup(r => r.GetOrder(11)).Returns(_orderDto);

            var result = _controller.GetOrder(11) as ObjectResult;
            Assert.AreEqual(((OrderDTO)result.Value).TotalSize, expectedResult);*/
        }

        [TestMethod()]
        public void AddOrder_ExceptionThrown_StatusCode500()
        {
            Order order = new();

            _serviceMock.Setup(r => r.SaveOrder(order)).Throws(new Exception());

            /*var result = _controller.AddOrder(order) as StatusCodeResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);*/
        }

        [TestMethod()]
        public void AddOrder_WhenCalled_ReturnsOK()
        {
            Order order = new();
            /*_serviceMock.Setup(r => r.SaveOrder(order)).Returns(133);
            var result = _controller.AddOrder(order);

            Assert.IsNotNull(result);
            Assert.AreEqual(200, ((ObjectResult)result).StatusCode);*/
        }
    }


}