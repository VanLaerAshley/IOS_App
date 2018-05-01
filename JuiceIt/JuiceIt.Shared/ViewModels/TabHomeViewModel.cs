using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using JuiceIt.Shared.Models;
using JuiceIt.Shared.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.File;

namespace JuiceIt.Shared.ViewModels
{
    public class TabHomeViewModel : MvxViewModel
    {
        private IMvxFileStore _fileStore;
        private readonly IRecipeService _recipeService;
        public TabHomeViewModel(IRecipeService recipeService, IMvxFileStore fileStore)
        {
            this._fileStore = fileStore;
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
            Recipes = await _recipeService.GetRecipes();
            int counter = Recipes.Count;

            Random rnd = new Random();
            int RandomNumber = rnd.Next(1, counter);
            string rndNumToStr = RandomNumber.ToString();
            DateTime dateAndTime = DateTime.Now;
            string day = dateAndTime.ToString("dd/MM/yyyy");
            string folderValue = (day + "," + rndNumToStr);
            var _folderName = "TextFilesFolder";
            var _fileName = "TextFile.txt";

            string value = string.Empty;
            _fileStore.TryReadTextFile(_folderName + "/" + _fileName, out (value));
            string fV = value;
            List<string> TextFileList = new List<string>(
                fV.Split(new string[] { "," }, StringSplitOptions.None));
            

            if(TextFileList[0] != day)
            {
                try
                {
                    if (!_fileStore.FolderExists(_folderName))
                        _fileStore.EnsureFolderExists(_folderName);
                    _fileStore.WriteFile(_folderName + "/" + _fileName, folderValue);

                    string NewValue = string.Empty;
                    _fileStore.TryReadTextFile(_folderName + "/" + _fileName, out (NewValue));
                    string NValue = NewValue;
                    List<string> NewTextFileList = new List<string>(
                        fV.Split(new string[] { "," }, StringSplitOptions.None));
                    int numVall = Int32.Parse(NewTextFileList[1]); 
                    int NewRandomValue = numVall;
                    RecipeContent = await _recipeService.GetRecipeById(NewRandomValue);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                int numVall = Int32.Parse(TextFileList[1]);
                int NewRandomValue = numVall;
                RecipeContent = await _recipeService.GetRecipeById(NewRandomValue);
            }

        }

    }
}
