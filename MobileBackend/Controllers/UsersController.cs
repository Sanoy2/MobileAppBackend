using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileBackend.Commands;
using MobileBackend.Commands.Users;
using MobileBackend.Services;
using MobileBackend.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileBackend.Controllers
{
    public class UsersController : ApiControllerBase
    {
        private readonly IUserService userService;
        private readonly GeneralSettings settings;

        public UsersController(
            IUserService userService, 
            ICommandDispatcher commandDispatcher,
            GeneralSettings settings)   
            : base(commandDispatcher)
        {
            this.userService = userService;
            this.settings = settings;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await userService.GetAllUsersAsync();
            var something = settings.Name;
            return Ok(something);
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
