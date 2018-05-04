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

        public async void Init(int FavoriteId)
        {
            this.FavoriteContent = await _localFavService.GetFavoriteById(FavoriteId);
            RaisePropertyChanged(() => Ingredients);
            RaisePropertyChanged(() => Conditions);
        }

        private string _ingredients;

        public string Ingredients
        {
            get
            {
                if (FavoriteContent?.ingredients == null) // IDK if FavoriteContent is a property or a class, I assumed is a property
                    return string.Empty; // or return string.empty;
                
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
                if (FavoriteContent?.condition == null) // IDK if FavoriteContent is a property or a class, I assumed is a property
                    return null; // or return string.empty;

                string[] namesArray = FavoriteContent.condition.Split(',');
                List<string> namesList = new List<string>(namesArray.Length);
                namesList.AddRange(namesArray);
                namesList.Reverse();
                _conditions = string.Join("\n", namesList);
                return _conditions;
            }
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
