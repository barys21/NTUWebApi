using Microsoft.AspNetCore.Mvc;
using NTUWebApi.Models;
using NTUWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTUWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly OrderItemAppService _orderItemAppService;

        public OrderItemController(OrderItemAppService orderItemAppService)
        {
            _orderItemAppService = orderItemAppService;
        }
        // GET api/orderitems
        [HttpGet]
        public ActionResult<List<OrderItem>> Get()
        {
            return _orderItemAppService.GetAll();
        }

        // GET api/orderitems/5
        [HttpGet("{id}")]
        public ActionResult<OrderItem> GetByOrderId(int id)
        {
            return _orderItemAppService.GetByOrderId(id);
        }

        // POST api/orderitems
        [HttpPost]
        public void Post(OrderItem orderItem)
        {
            _orderItemAppService.Create(orderItem);
        }

        // PUT api/orderitems/5
        [HttpPut("{id}")]
        public void PutByOrderId(OrderItem orderItem)
        {
            _orderItemAppService.UpdateOrderId(orderItem);
        }

        // DELETE api/orderitems/5
        [HttpDelete("{id}")]
        public void DeleteByOrderId(int id)
        {
            _orderItemAppService.DeleteByOrderId(id);
        }
    }
}
