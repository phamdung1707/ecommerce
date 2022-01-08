using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ecommerce_be.Models;
using ecommerce_be.Services.Users;
using ecommerce_be.Services.Users.Request;
using Microsoft.AspNetCore.Authorization;

namespace ecommerce_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = await _userService.Register(request);

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _userService.Login(request);

            return Ok(result);
        }

        //[Authorize]
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] User request)
        {
            var result = await _userService.Update(request);

            return Ok(result);
        }

        //[Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _userService.GetById(id);

            return Ok(result);
        }
    }
}
