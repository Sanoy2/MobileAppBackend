using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileBackend.Commands;
using MobileBackend.Commands.Users;
using MobileBackend.Extensions;
using MobileBackend.Handlers;
using MobileBackend.Models.Enums;
using MobileBackend.Services;
using MobileBackend.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MobileBackend.Controllers
{
    public class UsersController : ApiControllerBase
    {
        private readonly IUserService userService;
        private readonly GeneralSettings settings;
        private readonly IJwtHandler jwtHandler;

        public UsersController(
            IUserService userService, 
            ICommandDispatcher commandDispatcher,
            GeneralSettings settings,
            IJwtHandler jwtHandler)   
            : base(commandDispatcher)
        {
            this.userService = userService;
            this.settings = settings;
            this.jwtHandler = jwtHandler;
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
        [Route("register")]
        public async Task<IActionResult> Register([FromBody]CreateUser command)
        { 
            try
            {
                await commandDispatcher.DispatchAsync(command);

                return StatusCode((int)HttpStatusCode.Created, "Account created");
            }
            catch(Exception e)
            {
                return StatusCode((int)HttpStatusCode.Unauthorized, e.Message);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody]LoginUser command)
        {
            //await commandDispatcher.DispatchAsync(command);

            try
            {
                var token = await userService.LoginAsync(command.Email, command.Password);
                return Ok(token);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.Unauthorized, e.Message);
            }
        }

        [HttpGet]
        [Route("token")]
        public IActionResult Token()
        {
            var token = jwtHandler.CreateToken("me@email.com", 7491, "user");

            return Ok(token);
        }

        [HttpGet]
        [Authorize]
        [Route("auth")]
        public IActionResult OnAuth()
        {
            return Content($"User : {HttpContext.GetJwtPayload(JwtEnums.userEmail)}, Id: {HttpContext.GetJwtPayload(JwtEnums.userId)}");
        }
    }
}
