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
        public IActionResult GetAllUsers()
        {
            return Ok(userService.GetAllUsers());
        }

        [HttpGet("{username}")]
        public IActionResult GetUser(string username)
        {
            return Ok(userService.GetUser(username));
        }

        [HttpPost]
        public IActionResult Register([FromBody]CreateUser newUser)
        {
            userService.Register(newUser.Username, newUser.Password);
            return Ok(StatusCodes.Status201Created);
        }
    }
}
