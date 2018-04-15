using System.Collections.Generic;
using System.Threading.Tasks;
using JuiceIt.Core.Models;

namespace JuiceIt.Core.Services
{
    public interface IRecipeService
    {
        Task<List<Recipe>> GetRecipes();
    }
}