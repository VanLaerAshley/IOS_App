using System;
using JuiceIt.Shared.Models;
using JuiceIt.Shared.Services;
using MvvmCross.Core.ViewModels;

namespace JuiceIt.Shared.ViewModels
{
    public class TabHomeViewModel : MvxViewModel
    {
        private readonly IRecipeService _recipeService;
        public TabHomeViewModel(IRecipeService recipeService)
        {
            this._recipeService = recipeService;
            GetRecipesData();
        }
        private Recipe _recipeContent;
        public Recipe RecipeContent
        {
            get { return _recipeContent; }
            set
            {
                _recipeContent = value;
                RaisePropertyChanged(() => RecipeContent);
            }
        }
        public async void GetRecipesData()
        {
            RecipeContent = await _recipeService.GetRecipeById(1);
        }

    }
}
