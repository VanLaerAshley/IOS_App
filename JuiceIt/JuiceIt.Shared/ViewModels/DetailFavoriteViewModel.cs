using System;
using System.Collections.Generic;
using System.Windows.Input;
using JuiceIt.Shared.Models;
using JuiceIt.Shared.Services;
using MvvmCross.Core.ViewModels;

namespace JuiceIt.Shared.ViewModels
{
    public class DetailFavoriteViewModel : MvxViewModel
    {
        private readonly ILocalDbService _localFavService;
        private readonly ILocalShopListService _localShopListService;



        public DetailFavoriteViewModel(ILocalDbService localFavService, ILocalShopListService localShopListService)
        {
            this._localFavService = localFavService;
            this._localShopListService = localShopListService;
        }

        private Favorites _favoriteContent;

        public Favorites FavoriteContent
        {
            get { return _favoriteContent; }
            set
            {
                _favoriteContent = value;
                RaisePropertyChanged(() => FavoriteContent);
            }
        }

        private string _ingredients;

        public string Ingredients
        {
            get
            {
                string[] namesArray = FavoriteContent.ingredients.Split(',');
                List<string> namesList = new List<string>(namesArray.Length);
                namesList.AddRange(namesArray);
                namesList.Reverse();
                _ingredients = string.Join("\n", namesList);
                return _ingredients;
            }
        }

        private string _conditions;

        public string Conditions
        {
            get
            {
                string[] namesArray = FavoriteContent.condition.Split(',');
                List<string> namesList = new List<string>(namesArray.Length);
                namesList.AddRange(namesArray);
                namesList.Reverse();
                _conditions = string.Join("\n", namesList);
                return _conditions;
            }
        }



        public async void Init(int FavoriteId)
        {
            this.FavoriteContent = await _localFavService.GetFavoriteById(FavoriteId);
            RaisePropertyChanged(() => FavoriteContent);
        }



        public ICommand PostShopListCommand
        {
            get
            {
                return new MvxCommand(AddShopList);
            }
        }

        public void AddShopList()
        {
            _localShopListService.AddShopListFromLocal(FavoriteContent);
        }

    }
}
