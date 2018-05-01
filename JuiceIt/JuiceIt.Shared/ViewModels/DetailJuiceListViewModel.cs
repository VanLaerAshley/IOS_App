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
        private readonly ILocalShopListService _localShopListService;



        public DetailJuiceListViewModel( IRecipeService recipeService, ILocalDbService localDbService, ILocalShopListService localShopListService)
        {
            this._recipeService = recipeService;
            this._localDbService = localDbService;
            this._localShopListService = localShopListService;
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

        private Recipe _ingredient;

        public Recipe Ingredient
        {
            get
            {
                return _ingredient;
            }
            set
            {
                _ingredient = value;
                RaisePropertyChanged(() => Ingredient);
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

        public void AddFavorite()
        {
            _localDbService.AddFavorites(RecipeContent);

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
            _localShopListService.AddShopList(RecipeContent);
        }



    }
}
