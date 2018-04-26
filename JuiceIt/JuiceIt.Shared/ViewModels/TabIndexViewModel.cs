using System;
using System.Collections.Generic;
using JuiceIt.Shared.Models;
using JuiceIt.Shared.Services;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace JuiceIt.Shared.ViewModels
{
    public class TabIndexViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private IRecipeService _recipeService;
        public TabIndexViewModel(IRecipeService recipeService, IMvxNavigationService navigationService)
        {
            this._recipeService = recipeService;
            this._navigationService = navigationService;
            GetRecipesData();
        }

        private List<Recipe> _recipes;

        public List<Recipe> Recipes
        {
            get
            {
                return _recipes;
            }
            set
            {
                _recipes = value;
                RaisePropertyChanged(() => Recipes);
            }
        }

        public async void GetRecipesData()
        {
            Recipes = await _recipeService.GetRecipes();;
            RaisePropertyChanged(() => Recipes);
        }

        public MvxCommand<Recipe> NavigateToDetailCommand
        {
            get
            {
                return new MvxCommand<Recipe>(selectedRecipe =>
                {
                    ShowViewModel<DetailJuiceListViewModel>(new { RecipeId = selectedRecipe.id });
                });
            }
        }
    }
}
