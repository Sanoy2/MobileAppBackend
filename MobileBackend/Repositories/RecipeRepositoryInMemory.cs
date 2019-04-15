using MobileBackend.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileBackend.Repositories
{
    public class RecipeRepositoryInMemory
    {
        private static ISet<Recipe> recipes = new HashSet<Recipe>();
    }
}