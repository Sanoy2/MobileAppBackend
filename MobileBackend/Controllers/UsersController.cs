using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileBackend.Commands;
using MobileBackend.Commands.Users;
using MobileBackend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileBackend.Controllers
{
    public class UsersController : ApiControllerBase
    {
        private readonly IUserService userService;

        public UsersController(
            IUserService userService, 
            ICommandDispatcher commandDispatcher)
            : base(commandDispatcher)
        {
            this.userService = userService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetUser(string email)
        {            
            var user = await userService.GetUserAsync(email);

            if(user == null)
            {
                return NotFound("User not found");
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]CreateUser command)
        { 
            await commandDispatcher.DispatchAsync(command);

            return Created($"api/users/{command.Email}", new object());
        }
    }
}
