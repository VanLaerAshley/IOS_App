using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using JuiceIt.Shared.Models;
using JuiceIt.Shared.Services;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace JuiceIt.Shared.ViewModels
{
    public class DetailJuiceListViewModel : MvxViewModel
    {
        private readonly IRecipeService _recipeService;
        private readonly ILocalDbService _localDbService;
        private Recipe _recipeContent;

        public DetailJuiceListViewModel(IRecipeService recipeService, ILocalDbService localDbService)
        {
            this._recipeService = recipeService;
            this._localDbService = localDbService;
        }

        public Recipe RecipeContent
        {
            get { return _recipeContent; }
            set
            {
                _recipeContent = value;
                RaisePropertyChanged(() => RecipeContent);
            }
        }
        private string _ingredients;

        public string Ingredients
        {
            get { 
                _ingredients = string.Join("\n", RecipeContent.ingredients.ToArray());
                return _ingredients; 
            }
        }

        private string _conditions;

        public string Conditions
        {
            get
            {
                _conditions = string.Join("\n", RecipeContent.condition.ToArray());
                return _conditions;
            }
        }


        public async void Init(int RecipeId)
        {
            this.RecipeContent = await _recipeService.GetRecipeById(RecipeId);
            RaisePropertyChanged(() => RecipeContent);
        }

        public ICommand PostFavoriteCommand
        {
            get
            {
                return new MvxCommand(AddFavorite);
            }
        }
        private TabFavoriteViewModel _tabFavoriteViewModel;
        public void AddFavorite()
        {
            _localDbService.AddFavorites(RecipeContent);
            //_tabFavoriteViewModel.GetFavoriteData();
            //this.ReloadFromBundle<TabFavoriteViewModel>();
        }
    }
}
