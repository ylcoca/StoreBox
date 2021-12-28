﻿using StoreBox.Config;
using StoreBox.Entities.Models;
using StoreBox.Repository;
using System.Collections.Generic;

namespace StoreBox.Service
{
    public class OrderService : IOrderService
    {
        IOrderRepository _repository;
        StoreBoxConfiguration _configuration;
        public OrderService(IOrderRepository repository, StoreBoxConfiguration myConfiguration)
        {
            _repository = repository;
            _configuration = myConfiguration;
        }
        public OrderDTO GetOrder(int Id)
        {
            OrderDTO dto = null;

            var products = _repository.GetOrderProductTypes(Id);

            if (products != null)
            {
                var productList = new List<ProductTypeDTO>();

                foreach (var product in products)
                {
                    productList.Add(new ProductTypeDTO
                    {
                        ProductTypeName = product.ProductTypeName,
                        Width = product.Width
                    });
                }

                dto = new OrderDTO
                {
                    TotalSize = TotalSize(products),
                    Products = productList
                };
            }

            return dto;
        }

        public float SaveOrder(Order order)
        {
            var Id = _repository.SaveOrder(order);

            return GetOrder(Id).TotalSize;
        }

        private float TotalSize(IEnumerable<ProductType> products)
        {
            int cups = 0;
            float cupsValue = 0;
            float totalSize = 0;

            foreach (var product in products)
            {
                if (product.Symbol == ".")
                {
                    cups++;
                    cupsValue = product.Width;
                }
                else
                {
                    totalSize += product.Width;
                }
            }

            if (cups > 0 && cupsValue > 0)
            {
                if (cups % 4 == 0)
                {
                    totalSize += cups / _configuration.MaxMugs * cupsValue;
                }
                else
                {
                    totalSize += cups / _configuration.MaxMugs * cupsValue + cupsValue;
                }
            }

            return totalSize;
        }
    }
}