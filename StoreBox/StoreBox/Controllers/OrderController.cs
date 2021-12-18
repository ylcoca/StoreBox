using Microsoft.AspNetCore.Mvc;
using StoreBox.Models;
using StoreBox.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public IActionResult Get(int id)
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
        public int AddOrder([FromBody] Order order)
        {
            //should responds with the minimum bin width.
            
            _service.SaveOrder(new Order());
            return 0;


        }
    }
}
