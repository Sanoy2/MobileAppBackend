using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MobileBackend.DTO;
using MobileBackend.Models.Domain;
using MobileBackend.Repositories;

namespace MobileBackend.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository recipeRepository;
        private readonly IMapper mapper;

        public RecipeService(IRecipeRepository recipeRepository, IMapper mapper)
        {
            this.recipeRepository = recipeRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<RecipeDto>> GetAllAvailableForUserAsync(int userId)
        {
            var recipes = await recipeRepository.GetAllAvailableForUserAsync(userId);
            return recipes.Select(n => mapper.Map<Recipe, RecipeDto>(n)).ToList();
        }

        public async Task<IEnumerable<RecipeDto>> GetAllPublicRecipes()
        {
            var recipes = await recipeRepository.GetAllPublicAsync();
            return recipes.Select(n => mapper.Map<Recipe, RecipeDto>(n)).ToList();
        }

        public async Task AddAsync(int authorId, string name, string shortDescription, string description, short neededTimeMinutes, bool isPrivate = false, string imageUrl = null)
        {
            var recipe = new Recipe(authorId, name, shortDescription, description, neededTimeMinutes, isPrivate, imageUrl);
            await recipeRepository.AddAsync(recipe);
        }

        public async Task<RecipeDto> GetRecipeAsync(int recipeId)
        {
            var recipe = await recipeRepository.GetRecipeAsync(recipeId);
            return mapper.Map<Recipe, RecipeDto>(recipe);
        }

        public async Task<IEnumerable<RecipeDto>> GetRecipesAsync()
        {
            var recipes = await recipeRepository.GetAllAsync();
            return recipes.Select(n => mapper.Map<Recipe, RecipeDto>(n)).ToList();
        }

        public async Task<IEnumerable<RecipeDto>> GetRecipesAsync(int authorId)
        {
            var recipes = await recipeRepository.GetUsersRecipesAsync(authorId);
            return recipes.Select(n => mapper.Map<Recipe, RecipeDto>(n)).ToList();
        }

        public async Task RemoveAsync(int recipeId)
        {
            await recipeRepository.RemoveAsync(recipeId);
        }

        public Task UpdateAsync(Recipe recipe)
        {
            throw new System.NotImplementedException();
        }
    }
}