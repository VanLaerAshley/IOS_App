using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JuiceIt.Core.Models;

namespace JuiceIt.Core.Repositories
{
    public class RecipeRepository : BaseRepository, IRecipeRepository
    {
        private const string _BASEURL = "https://juiceit.azurewebsites.net/api/juiceit/";

        public Task<List<Recipe>> GetRecipes()
        {
            string url = String.Format("{0}{1}", _BASEURL, "data");
            return GetAsync<List<Recipe>>(url);
        }
    }
}
