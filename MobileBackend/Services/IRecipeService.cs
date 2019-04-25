using MobileBackend.DTO;
using MobileBackend.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileBackend.Services
{
    public interface IRecipeService : IService
    {
        Task<RecipeDto> GetRecipeAsync(int recipeId);
        Task<IEnumerable<RecipeDto>> GetRecipesAsync();
        Task<IEnumerable<RecipeDto>> GetRecipesAsync(int authorId);
        Task AddAsync(int authorId, string name, string shortDescription, string description, short neededTimeMinutes);
        Task RemoveAsync(int recipeId);
        Task UpdateAsync(Recipe recipe);
    }
}
