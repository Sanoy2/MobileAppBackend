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
        Task<IEnumerable<RecipeDto>> GetRecipesAsync(int authorId); // get recipes of this user
        Task<IEnumerable<RecipeDto>> GetAllAvailableForUserAsync(int userId); // get all public recipes and private of this user
        Task<IEnumerable<RecipeDto>> GetAllPublicRecipes();
        Task AddAsync(int authorId, string name, string shortDescription, string description, short neededTimeMinutes, bool isPrivate = false, string imageUrl = null);
        Task RemoveAsync(int recipeId);
        Task UpdateAsync(Recipe recipe);
    }
}
