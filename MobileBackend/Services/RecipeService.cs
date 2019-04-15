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

        public async Task AddAsync(int authorId, string name, string shortDescription, string description, short neededTimeMinutes)
        {
            var recipe = new Recipe(authorId, name, shortDescription, description, neededTimeMinutes);
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
    }
}