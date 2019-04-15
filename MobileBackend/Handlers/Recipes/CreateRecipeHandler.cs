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
        public CreateRecipeHandler()
        {
            
        }
        public async Task HandleAsync(CreateRecipe command)
        {
            
        }
    }
}