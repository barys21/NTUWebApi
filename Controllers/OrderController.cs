using Microsoft.AspNetCore.Mvc;
using NTUWebApi.Models;
using NTUWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTUWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController :ControllerBase
    {
        private readonly OrderAppService _orderAppService;

        public OrderController(OrderAppService orderAppService) 
        {
            _orderAppService = orderAppService;
        }

        // GET api/orders
        [HttpGet]
        public ActionResult<List<Order>> Get()
        {
            return _orderAppService.GetAll();
        }

        // GET api/orders/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            return _orderAppService.GetById(id);
        }

        // POST api/orders
        [HttpPost]
        public void Post(Order order)
        {
            _orderAppService.Create(order);
        }

        // PUT api/orders/5
        [HttpPut("{id}")]
        public void Put(Order order)
        {
            _orderAppService.Update(order);
        }

        // DELETE api/orders/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _orderAppService.Delete(id);
        }
    }
}
