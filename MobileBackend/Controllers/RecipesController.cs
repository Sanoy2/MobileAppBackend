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
            var recipes = await recipeService.GetRecipesAsync();
            return Ok(recipes);
        }

        [HttpGet]
        [Authorize]
        [Route("loggeduser")]
        public async Task<IActionResult> GetRecipesWithUserId()
        {
            int userId;
            if(Int32.TryParse(HttpContext.GetJwtPayload(JwtEnums.userId), out userId))
            {
                var recipes = await recipeService.GetAllAvailableForUserAsync(userId);
                return Ok(recipes);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "Something is wrong with user id");
            }
        }
    }
}
