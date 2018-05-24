using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuiceIt.Shared.Models;

namespace JuiceIt.Shared.Repositories
{
    public class RecipeRepository : BaseRepository, IRecipeRepository
    {
        private const string _BASEURL = "https://juiceit.azurewebsites.net/api/juiceit/data";
        private List<Recipe> _recipes;

        public async Task<List<Recipe>> GetRecipes()
        {
            string url = _BASEURL;
            if (_recipes == null)
                _recipes = await GetAsync<List<Recipe>>(url);

            return _recipes;
        }

        public async Task<Recipe> GetRecipeDetails(int RecipeId)
        {
            if (_recipes == null) await GetRecipes();
            return _recipes.Where(recipe => recipe.id == RecipeId)?.First();
        }

        public Task<Recipe> GetRecipe(int RecipeId)
        {
            string url = String.Format("{0}/{1}", _BASEURL, RecipeId);
            return GetAsync<Recipe>(url);
        }
    }
}
