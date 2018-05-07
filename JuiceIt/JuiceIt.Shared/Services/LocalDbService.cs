using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JuiceIt.Shared.Models;
using JuiceIt.Shared.Repositories;

namespace JuiceIt.Shared.Services
{
    public class LocalDbService : ILocalDbService
    {
        private ILocalFavRepository _localFavRepository;
        public LocalDbService(ILocalFavRepository localFavRepository)
        {
            this._localFavRepository = localFavRepository;
        }

        public async Task<List<Favorites>> GetFavorite()
        {
            _localFavRepository.SetupDatabase();
            return await _localFavRepository.GetFavorites();
        }

        public async Task<List<Favorites>> GetFavoriteAgain()
        {
            
            return await _localFavRepository.GetFavorites();
        }

        public Task<Favorites> GetFavoriteById(int FavoriteId)
        {
            return _localFavRepository.GetFavoritesById(FavoriteId);
        }

        public Recipe AddFavorites(Recipe recipe)
        {

            _localFavRepository.AddFavorites(recipe);
            return recipe;
        }

        public async Task DeleteFavorite(int id)
        {
            await _localFavRepository.DeleteFavorite(id);
        }
    }
}
