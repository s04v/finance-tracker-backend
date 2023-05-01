using FinanceTracker.Data;
using FinanceTracker.Models;
using FinanceTracker.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FinanceTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this._userService.GetOne());
        }

        [HttpPost("login")]
        public IActionResult Login(User user)
        {
            var token = this._userService.Login(user);
            if(token == null)
            {
                return BadRequest("Wrong login or password");
            }

            return Ok(token);
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            var createdUser = this._userService.Create(user);
            if(createdUser == null) 
            {
                return BadRequest("User already exists");
            }

            return Ok(createdUser);
        }
    }
}
