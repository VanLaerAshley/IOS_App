using System.Collections.Generic;
using System.Threading.Tasks;
using JuiceIt.Shared.Models;

namespace JuiceIt.Shared.Services
{
    public interface ILocalShopListService
    {
        Recipe AddShopList(Recipe recipe);
        Favorites AddShopListFromLocal(Favorites favorite);
        Task<List<ShopList>> GetShopList();
        Task DeleteShopListItem(int id);
        ShopList AddShopListChecker();
        Task<List<ShopList>> GetShopListAgain();
    }
}