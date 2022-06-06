using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using StoreBox.Entities.Models;
using StoreBox.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreBox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;
        private const string CacheKey = "Order";
        private readonly IMemoryCache _cache;
        public OrderController(IOrderService service, IMemoryCache cache)
        {
            _service = service;
            _cache = cache;
        }
        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            try
            {
                if (_cache.TryGetValue(CacheKey, out IEnumerable<Order> order))
                {
                    return Ok(order);
                }
                else
                {
                    if (id < 1)
                    {
                        return BadRequest("Id its not valid");
                    }

                    if (!ModelState.IsValid)
                    {
                        return BadRequest("Invalid model object");
                    }

                    var result = await _service.GetOrder(id);
                    if (result == null)
                    {
                        return NotFound();
                    }
                    return Ok(result);
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }

        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] Order order)
        {
            try
            {
                if (order == null)
                {
                    return BadRequest("Order object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var minWidth = await _service.SaveOrder(order);
                return Ok(minWidth);
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error");
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                return Ok(await _service.DeleteOrder(id));
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }

        }
    }
}
