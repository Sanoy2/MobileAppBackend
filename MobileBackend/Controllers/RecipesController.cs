using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using MobileBackend.Commands;
using MobileBackend.Commands.Users;
using MobileBackend.Extensions;
using MobileBackend.Handlers;
using MobileBackend.Models.Enums;
using MobileBackend.Services;
using MobileBackend.Settings;
using MobileBackend.Commands.Recipes;

namespace MobileBackend.Controllers
{
    public class RecipesController : ApiControllerBase
    {
        private readonly IRecipeService recipeService;
        private readonly IJwtHandler jwtHandler;

        public RecipesController(
            ICommandDispatcher commandDispatcher,
            IJwtHandler jwtHandler,
            IRecipeService recipeService)   
            : base(commandDispatcher)
        {
            this.jwtHandler = jwtHandler;
            this.recipeService = recipeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecipes()
        {
            System.Console.WriteLine(DateTime.Now);
            System.Console.WriteLine("Calling when user not logged");
            var recipes = await recipeService.GetAllPublicRecipes();
            System.Console.WriteLine("I'm done");
            return Ok(recipes);
        }
 
        [HttpGet]
        [Authorize]
        [Route("loggeduser")]
        public async Task<IActionResult> GetRecipesWithUserId()
        {
            System.Console.WriteLine(DateTime.Now);
            System.Console.WriteLine("Calling when user logged in");
            int userId;
            if(Int32.TryParse(HttpContext.GetJwtPayload(JwtEnums.userId), out userId))
            {
                var recipes = await recipeService.GetAllAvailableForUserAsync(userId);
                System.Console.WriteLine("I'm done");
                return Ok(recipes);
            }
            else
            {
                System.Console.WriteLine("Cant parse user id");
                return StatusCode((int)HttpStatusCode.BadRequest, "Something is wrong with user id");
            }
        }

        [HttpGet]
        [Authorize]
        [Route("my")]
        public async Task<IActionResult> GetUsersRecipes()
        {
            System.Console.WriteLine(DateTime.Now);
            System.Console.WriteLine("Calling when user logged in");
            int userId;
            if(Int32.TryParse(HttpContext.GetJwtPayload(JwtEnums.userId), out userId))
            {
                var recipes = await recipeService.GetRecipesAsync(userId);
                System.Console.WriteLine("I'm done");
                return Ok(recipes);
            }
            else
            {
                System.Console.WriteLine("Cant parse user id");
                return StatusCode((int)HttpStatusCode.BadRequest, "Something is wrong with user id");
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateRecipe([FromBody] CreateRecipe command)
        {
            System.Console.WriteLine(DateTime.Now);
            System.Console.WriteLine("Creating new recipe");
            if(command == null)
            {
                System.Console.WriteLine("I GOT NULL");
                return StatusCode((int)HttpStatusCode.BadRequest, "Something is wrong with your data :(");
            }
            System.Console.WriteLine(command.ToString());
            int userId;
            if(Int32.TryParse(HttpContext.GetJwtPayload(JwtEnums.userId), out userId))
            {
                try
                {
                    await recipeService.AddAsync(
                        userId, 
                        command.Name, 
                        command.ShortDescription, 
                        command.Description, 
                        command.NeededTimeMinutes, 
                        command.IsPrivate, 
                        command.MainImageUrl);
                    System.Console.WriteLine("I'm done");
                    return Ok();
                }
                catch(Exception e)
                {
                    System.Console.WriteLine(e.Message);
                    return StatusCode((int)HttpStatusCode.BadRequest, "Something is your data :(");
                }
            }
            else
            {
                System.Console.WriteLine("Cant parse user id");
                return StatusCode((int)HttpStatusCode.BadRequest, "Something is wrong with user id :(");
            }
        }
    }
}
