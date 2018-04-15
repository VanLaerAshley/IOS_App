using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JuiceIt.Core.Models;
using JuiceIt.Core.Repositories;

namespace JuiceIt.Core.Services
{
    public class RecipeService : IRecipeService
    {
        private IRecipeRepository _recipeRepository;
        public RecipeService(IRecipeRepository recipeRepository)
        {
            this._recipeRepository = recipeRepository;
        }

        public async Task<List<Recipe>> GetRecipes()
        {
            return await _recipeRepository.GetRecipes();
        }
    }
}
