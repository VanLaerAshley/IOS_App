using System.Collections.Generic;
using System.Threading.Tasks;
using JuiceIt.Shared.Models;

namespace JuiceIt.Shared.Repositories
{
    public interface ILocalShopListRepository
    {
        ShopList AddShopList(Recipe recipe);
        void SetupDatabase();
        Task<List<ShopList>> GetShopList();
        Task DeleteShopListItem(int id);
    }
}