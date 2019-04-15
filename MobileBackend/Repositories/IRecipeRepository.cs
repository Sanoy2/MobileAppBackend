using MobileBackend.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileBackend.Repositories
{
    public interface IRecipeRepository : IRepository
    {
        Task<IEnumerable<Recipe>> GetAllAsync();
        Task<IEnumerable<Recipe>> GetUsersRecipesAsync(int userId);
        Task<Recipe> GetRecipeAsync(int recipeId);
        Task AddAsync(Recipe recipe);
        Task UpdateAsync(Recipe recipe);
        Task RemoveAsync(int recipeId);
    }
}
