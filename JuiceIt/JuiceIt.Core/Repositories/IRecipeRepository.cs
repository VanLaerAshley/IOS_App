using System.Collections.Generic;
using System.Threading.Tasks;
using JuiceIt.Core.Models;

namespace JuiceIt.Core.Repositories
{
    public interface IRecipeRepository
    {
        Task<List<Recipe>> GetRecipes();
    }
}