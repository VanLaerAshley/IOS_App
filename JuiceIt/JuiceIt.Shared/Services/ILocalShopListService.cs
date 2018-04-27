using System.Collections.Generic;
using System.Threading.Tasks;
using JuiceIt.Shared.Models;

namespace JuiceIt.Shared.Services
{
    public interface ILocalShopListService
    {
        Recipe AddShopList(Recipe recipe);
        Task<List<ShopList>> GetShopList();
        Task DeleteShopListItem(int id);
    }
}