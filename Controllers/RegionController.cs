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
    public class RegionController : ControllerBase
    {
        private readonly RegionAppService _regionAppService;

        public RegionController(RegionAppService regionAppService)
        {
            _regionAppService = regionAppService;
        }

        // GET api/regions
        [HttpGet]
        public ActionResult<List<Region>> Get()
        {
            return _regionAppService.GetAll();
        }

        // GET api/regions/5
        [HttpGet("{id}")]
        public ActionResult<Region> Get(int id)
        {
            return _regionAppService.GetById(id);
        }

        // POST api/regions
        [HttpPost]
        public void Post(Region region)
        {
            _regionAppService.Create(region);
        }

        // PUT api/regions/5
        [HttpPut("{id}")]
        public void Put(Region region)
        {
            _regionAppService.Update(region);
        }

        // DELETE api/regions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _regionAppService.Delete(id);
        }
    }
}
