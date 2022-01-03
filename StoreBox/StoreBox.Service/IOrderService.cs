﻿using StoreBox.Entities.Models;
using System.Threading.Tasks;

namespace StoreBox.Service
{
    public interface IOrderService
    {
        public Task<float> SaveOrder(Order order);
        public Task<OrderDTO> GetOrder(int Id);
    }
}
