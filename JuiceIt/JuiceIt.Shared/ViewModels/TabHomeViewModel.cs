using System;
using JuiceIt.Shared.Models;
using JuiceIt.Shared.Services;
using MvvmCross.Core.ViewModels;

namespace JuiceIt.Shared.ViewModels
{
    public class TabHomeViewModel : MvxViewModel
    {
        //private readonly IRecipeService _recipeService;
        public TabHomeViewModel(IRecipeService recipeService)
        {
            //this._recipeService = recipeService;
        }
        //private Favorites _favoriteContent;
        //public Favorites FavoriteContent
        //{
        //    get { return _favoriteContent; }
        //    set
        //    {
        //        _favoriteContent = value;
        //        RaisePropertyChanged(() => FavoriteContent);
        //    }
        //}

        //public void Init()
        //{
        //    this.FavoriteContent = _recipeService.GetFavorite();
        //    RaisePropertyChanged(() => RecipeContent);
        //}
    }
}
