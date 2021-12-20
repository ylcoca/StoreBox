﻿using Microsoft.AspNetCore.Mvc;
using StoreBox.Models;
using StoreBox.Service;
using System;

namespace StoreBox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _service;
        public OrderController(IOrderService service)
        {
            _service = service;
        }
        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            try
            {
                var result = _service.GetOrder(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }

        }

        // POST api/<OrderController>
        [HttpPost]
        public IActionResult AddOrder([FromBody] Order order)
        {
            try
            {
                var minWidth = _service.SaveOrder(order);
                return Ok(minWidth);
            }
            catch (Exception e)
            {

                return StatusCode(500);
            }
            
        }
    }
}
