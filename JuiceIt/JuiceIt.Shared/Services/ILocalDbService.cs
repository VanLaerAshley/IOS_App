using System.Collections.Generic;
using System.Threading.Tasks;
using JuiceIt.Shared.Models;

namespace JuiceIt.Shared.Services
{
    public interface ILocalDbService
    {
        Task<List<Favorites>> GetFavorite();
        Recipe AddFavorites(Recipe recipe);
        Task DeleteFavorite(int id);
    }
}