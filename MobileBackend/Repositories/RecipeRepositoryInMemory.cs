using MobileBackend.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileBackend.Repositories
{
    public class RecipeRepositoryInMemory : IRecipeRepository
    {
        private static ISet<Recipe> recipes = new HashSet<Recipe>()
        {
            new Recipe(1, "Meatballs", "Short description", "Full description", 20),
            new Recipe(2, "Fries", "Short description", "Full description", 40),
            new Recipe(3, "Chicken wings", "Short description", "Full description", 30),
            new Recipe(3, "Hamburger", "Short description", "Full description", 25),
            new Recipe(1, "Chicken", "Short description", "Full description", 15),
            new Recipe(4, "Frying chicken", "Short description", "Full description", 90),
            new Recipe(5, "Tomato soup", "Short description", "Full description", 17),
            new Recipe(2, "Tomato soup", "Short description", "Full description", 45),
            new Recipe(2, "Pizza", "Short description", "Full description", 76),
            new Recipe(3, "Neapolitan Pizza", "Short description", "Full description", 44),
            new Recipe(4, "American pizza", "Short description", "Full description", 67),

        };

        public async Task AddAsync(Recipe recipe)
        {
            await Task.FromResult(recipes.Add(recipe));
        }

        public async Task<IEnumerable<Recipe>> GetAllAsync()
        {
            return await Task.FromResult(recipes.ToList());
        }

        public async Task<IEnumerable<Recipe>> GetUsersRecipesAsync(int userId)
        {
            return await Task.FromResult(recipes.Where(n => n.AuthorId == userId).ToList());
        }

        public async Task<Recipe> GetRecipe(int recipeId)
        {
            return await Task.Run(() => 
            {
                return recipes.SingleOrDefault(n => n.Id == recipeId);
            });
        }

        public async Task RemoveAsync(int recipeId)
        {
            var recipe = recipes.SingleOrDefault(n => n.Id == recipeId);
            if(recipe == null)
            {
                return;
            }
            await Task.FromResult(recipes.Remove(recipe));
        }

        public async Task UpdateAsync(Recipe recipe)
        {
            await Task.CompletedTask;
        }
    }
}