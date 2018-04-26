using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JuiceIt.Shared.Models;
using JuiceIt.Shared.Repositories;

namespace JuiceIt.Shared.Services
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

        public Task<Recipe> GetRecipeById(int RecipeId)
        {
            return _recipeRepository.GetRecipeDetails(RecipeId);
        }

        public async Task<Recipe> GetRecipe(int RecipeId)
        {
            return await _recipeRepository.GetRecipe(RecipeId);
        }


    }
}
