using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileBackend.Commands.Users;
using MobileBackend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileBackend.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetUser(string username)
        {
            var user = await userService.GetUserAsync(username);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]CreateUser newUser)
        {
            await userService.RegisterAsync(newUser.Username, newUser.Password);
            return Ok(StatusCodes.Status201Created);
        }
    }
}
