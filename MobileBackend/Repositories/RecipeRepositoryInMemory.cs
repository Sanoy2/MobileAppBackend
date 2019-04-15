using MobileBackend.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileBackend.Repositories
{
    public class RecipeRepositoryInMemory : IRecipeRepository
    {
        private static ISet<Recipe> recipes = new HashSet<Recipe>();

        public RecipeRepositoryInMemory()
        {
        }

        public Task AddAsync(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Recipe>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Recipe>> GetUsersRecipesAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int recipeId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Recipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}