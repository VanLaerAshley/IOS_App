using System.Collections.Generic;
using System.Threading.Tasks;
using JuiceIt.Shared.Models;

namespace JuiceIt.Shared.Services
{
    public interface ILocalDbService
    {
        Task<List<Favorites>> GetFavorite();
        Task<Favorites> GetFavoriteById(int FavoriteId);
        Recipe AddFavorites(Recipe recipe);
        Task DeleteFavorite(int id);
        Task<List<Favorites>> GetFavoriteAgain();
    }
}