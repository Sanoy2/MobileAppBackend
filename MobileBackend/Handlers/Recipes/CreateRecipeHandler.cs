using MobileBackend.Commands;
using MobileBackend.Commands.Recipes;
using MobileBackend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileBackend.Handlers.Recipes
{
    public class CreateRecipeHandler: ICommandHandler<CreateRecipe>
    {
        private readonly IRecipeService recipeService;

        public CreateRecipeHandler(IRecipeService recipeService)
        {
            this.recipeService = recipeService;
        }
        // this method wont work
        public async Task HandleAsync(CreateRecipe command)
        {
            await Task.FromResult(0);
        }
    }
}