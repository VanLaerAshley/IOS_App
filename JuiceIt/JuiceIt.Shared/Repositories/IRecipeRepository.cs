using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JuiceIt.Shared.Models;

namespace JuiceIt.Shared.Repositories
{
    public interface IRecipeRepository
    {
        Task<List<Recipe>> GetRecipes();
        Task<Recipe> GetRecipe(int RecipeId);
        Task<Recipe> GetRecipeDetails(int RecipeId);
    }
}