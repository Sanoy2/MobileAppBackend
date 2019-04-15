using System.Collections.Generic;
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

        public Task<IEnumerable<RecipeDto>> GetRecipesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<RecipeDto>> GetRecipesAsync(int authorId)
        {
            throw new System.NotImplementedException();
        }
    }
}