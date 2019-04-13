using MobileBackend.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileBackend.Repositories
{
    public interface IRecipesRepository
    {
        IEnumerable<Recipe> GetAll();
        IEnumerable<Recipe> GetUsersRecipes(int userId);
        void Add(Recipe recipe);
        void Update(Recipe recipe);
        void Remove(int recipeId);
    }
}
