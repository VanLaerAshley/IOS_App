using System;
using System.Collections.Generic;
using System.Linq;
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

        }

        public override void ViewAppearing()
        {
            base.ViewAppearing();
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

        private List<Recipe> _filteredRecepies = new List<Recipe>();
        public List<Recipe> FilteredRecepies
        {
            get
            {
                return _filteredRecepies;
            }
            set
            {
                _filteredRecepies = value;
                RaisePropertyChanged(() => FilteredRecepies);
            }
        }

        public void SearchJuices(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                FilteredRecepies = Recipes;
            else
            {
                FilteredRecepies = Recipes;
                FilteredRecepies = FilteredRecepies.Where(r => r.name.ToLowerInvariant().Contains(title.ToLowerInvariant())).ToList();
            }
        }

        public async void GetRecipesData()
        {
            Recipes = await _recipeService.GetRecipes();
            FilteredRecepies = Recipes;
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
