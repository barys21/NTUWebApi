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
    public class ItemController : ControllerBase
    {
        private readonly ItemAppService _itemAppService;

        public ItemController(ItemAppService itemAppService)
        {
            _itemAppService = itemAppService;
        }
        // GET api/items
        [HttpGet]
        public ActionResult<List<Item>> Get()
        {
            return _itemAppService.GetAll();
        }

        // GET api/items/5
        [HttpGet("{id}")]
        public ActionResult<Item> Get(int id)
        {
            return _itemAppService.GetById(id);
        }

        // POST api/items
        [HttpPost]
        public void Post(Item item)
        {
            _itemAppService.Create(item);
        }

        // PUT api/items/5
        [HttpPut("{id}")]
        public void Put(Item item)
        {
            _itemAppService.Update(item);
        }

        // DELETE api/items/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _itemAppService.Delete(id);
        }
    }
}
