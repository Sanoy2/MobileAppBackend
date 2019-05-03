using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
