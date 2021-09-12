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
    [ApiController]
    [Route("api/[controller]")]
    public class UserApiController : ControllerBase
    {
        private UserAppService _userAppService;

        public UserApiController(UserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(User user)
        {
            var _user = _userAppService.Authenticate(user.Username, user.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(_user.Token);
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            var users = _userAppService.GetAll();
            return Ok(users);
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public void Create(User user)
        {
            _userAppService.Create(user);
        }
    }
}
