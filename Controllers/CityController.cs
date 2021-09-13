using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class CityController : ControllerBase
    {
        private readonly CityAppService _cityAppService;

        public CityController(CityAppService cityAppService)
        {
            _cityAppService = cityAppService;
        }
        // GET api/cities
        [HttpGet]
        public ActionResult<List<City>> Get()
        {
            return _cityAppService.GetAll();
        }

        // GET api/cities/5
        [HttpGet("{id}")]
        public ActionResult<City> Get(int id)
        {
            return _cityAppService.GetById(id);
        }

        // POST api/cities
        [HttpPost]
        public void Post(City city)
        {
            _cityAppService.Create(city);
        }

        // PUT api/cities/5
        [HttpPut("{id}")]
        public void Put(City city)
        {
            _cityAppService.Update(city);
        }

        // DELETE api/cities/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _cityAppService.Delete(id);
        }
    }
}
