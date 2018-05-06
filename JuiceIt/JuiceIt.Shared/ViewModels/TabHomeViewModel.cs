using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;
using JuiceIt.Shared.Models;
using JuiceIt.Shared.Services;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.File;

namespace JuiceIt.Shared.ViewModels
{
    public class TabHomeViewModel : MvxViewModel
    {
        private IMvxFileStore _fileStore;
        private readonly IMvxNavigationService _navigationService;
        private readonly IRecipeService _recipeService;
        public TabHomeViewModel(IRecipeService recipeService, IMvxFileStore fileStore, IMvxNavigationService navigationService)
        {
            this._navigationService = navigationService;
            this._fileStore = fileStore;
            this._recipeService = recipeService;
            GetMorningJuice();
            GetAfternoonJuice();
            GetEveningJuice();
        }

        private Recipe _morningContent;
        public Recipe MorningContent
        {
            get { return _morningContent; }
            set
            {
                _morningContent = value;

            }
        }


        private Recipe _afternoonContent;
        public Recipe AfternoonContent
        {
            get { return _afternoonContent; }
            set
            {
                _afternoonContent = value;

            }
        }

        private Recipe _eveningContent;
        public Recipe EveningContent
        {
            get { return _eveningContent; }
            set
            {
                _eveningContent = value;

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

        public void Init(int index)
        {
            
        }

        public async void GetMorningJuice()
        {
            Recipes = await _recipeService.GetRecipes();
            int counter = Recipes.Count;

            Random rnd = new Random();
            int RandomNumber = rnd.Next(1, counter);
            string rndNumToStr = RandomNumber.ToString();
            DateTime dateAndTime = DateTime.Now;
            string day = dateAndTime.ToString("dd/MM/yyyy");
            string folderValue = (day + "," + rndNumToStr);
            var _folderName = "TextFilesFolder1";
            var _fileName = "MorningJuice";

            if (!_fileStore.FolderExists(_folderName))
                _fileStore.EnsureFolderExists(_folderName);

            //Content van de file uitlezen
            string value = string.Empty;
            _fileStore.TryReadTextFile(_folderName + "/" + _fileName, out (value));
            string CheckFileContent = value;
            string[] TextFileList;

            //Als er niets in zit, default data in steken
            if (CheckFileContent == null)
            {
                _fileStore.WriteFile(_folderName + "/" + _fileName, "00/00/00,0");
                string d = "00/00/00,0";
                TextFileList = d.Split(',');
            }
            else
            {
                TextFileList = CheckFileContent.Split(',');

            }

            if(TextFileList[0] != day)
            {
                try
                {
                    //File verwijderen om overbodige data te verwijderen.
                    _fileStore.DeleteFile(_folderName + "/" + _fileName);
                    //File aanmaken.
                    if (!_fileStore.FolderExists(_folderName))
                        _fileStore.EnsureFolderExists(_folderName);

                    _fileStore.WriteFile(_folderName + "/" + _fileName, folderValue);
                    string NewValue = string.Empty;
                    _fileStore.TryReadTextFile(_folderName + "/" + _fileName, out (NewValue));
                    string NValue = NewValue;

                    List<string> NewTextFileList = new List<string>(
                        NValue.Split(new string[] { "," }, StringSplitOptions.None));

                    int numVall = Int32.Parse(NewTextFileList[1]);
                    int NewRandomValue = numVall;
                    MorningContent = await _recipeService.GetRecipeById(NewRandomValue);
                    RaisePropertyChanged(() => MorningContent);
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
                MorningContent = await _recipeService.GetRecipeById(NewRandomValue);
                RaisePropertyChanged(() => MorningContent);
            }

        }

        private MvxCommand<Recipe> _navigateToMorningJuice;
        public MvxCommand<Recipe> NavigateToMorningJuice
        {
            get
            {
                if (_navigateToMorningJuice == null)
                    _navigateToMorningJuice = new MvxCommand<Recipe>(DoNavigateToMorningJuice);
                return _navigateToMorningJuice;
            }
        }

        private void DoNavigateToMorningJuice(Recipe selectedRecipe)
        {
            var _folderName = "TextFilesFolder1";
            var _fileName = "MorningJuice";
            string value = string.Empty;
            _fileStore.TryReadTextFile(_folderName + "/" + _fileName, out (value));
            string fV = value;

            List<string> TextFileList = new List<string>(
                fV.Split(new string[] { "," }, StringSplitOptions.None));
            int numVall = Int32.Parse(TextFileList[1]);
            int NewRandomValue = numVall;

            ShowViewModel<DetailJuiceListViewModel>(new { RecipeId = NewRandomValue });
        }




        public async void GetAfternoonJuice()
        {
            Recipes = await _recipeService.GetRecipes();
            int counter = Recipes.Count;

            Random rnd = new Random();
            int RandomNumber = rnd.Next(1, counter);
            string rndNumToStr = RandomNumber.ToString();
            DateTime dateAndTime = DateTime.Now;
            string day = dateAndTime.ToString("dd/MM/yyyy");
            string folderValue = (day + "," + rndNumToStr);
            var _folderName = "TextFilesFolder2";
            var _fileName = "AfternoonJuice";

            if (!_fileStore.FolderExists(_folderName))
                _fileStore.EnsureFolderExists(_folderName);
            
            //Content van de file uitlezen
            string value = string.Empty;
            _fileStore.TryReadTextFile(_folderName + "/" + _fileName, out (value));
            string CheckFileContent = value;
            string[] TextFileList;

            //Als er niets in zit, default data in steken
            if (CheckFileContent == null)
            {
                _fileStore.WriteFile(_folderName + "/" + _fileName, "00/00/00,0");
                string d = "00/00/00,0";
                TextFileList = d.Split(',');
            }
            else
            {
                TextFileList = CheckFileContent.Split(',');
             
            }


            if (TextFileList[0] != day)
            {

                    //File verwijderen om overbodige data te verwijderen.
                    _fileStore.DeleteFile(_folderName + "/" + _fileName);
                    //File aanmaken.
                    if (!_fileStore.FolderExists(_folderName))
                        _fileStore.EnsureFolderExists(_folderName);
                    
                    _fileStore.WriteFile(_folderName + "/" + _fileName, folderValue);
                    string NewValue = string.Empty;
                    _fileStore.TryReadTextFile(_folderName + "/" + _fileName, out (NewValue));
                    string NValue = NewValue;

                    List<string> NewTextFileList = new List<string>(
                    NValue.Split(new string[] { "," }, StringSplitOptions.None));
                    
                    int numVall = Int32.Parse(NewTextFileList[1]);
                    int NewRandomValue = numVall;
                    AfternoonContent = await _recipeService.GetRecipeById(NewRandomValue);
                    RaisePropertyChanged(() => AfternoonContent);

            }
            else
            {
                int numVall = Int32.Parse(TextFileList[1]);
                int NewRandomValue = numVall;
                AfternoonContent = await _recipeService.GetRecipeById(NewRandomValue);
                RaisePropertyChanged(() => AfternoonContent);
            }

        }


        private MvxCommand<Recipe> _navigateToAfternoonJuice;
        public MvxCommand<Recipe> NavigateToAfternoonJuice
        {
            get
            {
                if (_navigateToAfternoonJuice == null)
                    _navigateToAfternoonJuice = new MvxCommand<Recipe>(DoNavigateToAfternoonJuice);
                return _navigateToAfternoonJuice;
            }
        }

        private void DoNavigateToAfternoonJuice(Recipe selectedRecipe)
        {
            var _folderName = "TextFilesFolder2";
            var _fileName = "AfternoonJuice";
            string value = string.Empty;
            _fileStore.TryReadTextFile(_folderName + "/" + _fileName, out (value));
            string fV = value;

            List<string> TextFileList = new List<string>(
                fV.Split(new string[] { "," }, StringSplitOptions.None));
            int numVall = Int32.Parse(TextFileList[1]);
            int NewRandomValue = numVall;

            ShowViewModel<DetailJuiceListViewModel>(new { RecipeId = NewRandomValue });
        }


        public async void GetEveningJuice()
        {
            Recipes = await _recipeService.GetRecipes();
            int counter = Recipes.Count;

            Random rnd = new Random();
            int RandomNumber = rnd.Next(1, counter);
            string rndNumToStr = RandomNumber.ToString();
            DateTime dateAndTime = DateTime.Now;
            string day = dateAndTime.ToString("dd/MM/yyyy");
            string folderValue = (day + "," + rndNumToStr);
            var _folderName = "TextFilesFolder3";
            var _fileName = "EveningJuice";

            if (!_fileStore.FolderExists(_folderName))
                _fileStore.EnsureFolderExists(_folderName);

            //Content van de file uitlezen
            string value = string.Empty;
            _fileStore.TryReadTextFile(_folderName + "/" + _fileName, out (value));
            string CheckFileContent = value;
            string[] TextFileList;

            //Als er niets in zit, default data in steken
            if (CheckFileContent == null)
            {
                _fileStore.WriteFile(_folderName + "/" + _fileName, "00/00/00,0");
                string d = "00/00/00,0";
                TextFileList = d.Split(',');
            }
            else
            {
                TextFileList = CheckFileContent.Split(',');

            }

            if (TextFileList[0] != day)
            {
                try
                {
                    //File verwijderen om overbodige data te verwijderen.
                    _fileStore.DeleteFile(_folderName + "/" + _fileName);
                    //File aanmaken.
                    if (!_fileStore.FolderExists(_folderName))
                        _fileStore.EnsureFolderExists(_folderName);

                    _fileStore.WriteFile(_folderName + "/" + _fileName, folderValue);

                    string NewValue = string.Empty;
                    _fileStore.TryReadTextFile(_folderName + "/" + _fileName, out (NewValue));
                    string NValue = NewValue;

                    List<string> NewTextFileList = new List<string>(
                        NValue.Split(new string[] { "," }, StringSplitOptions.None));

                    int numVall = Int32.Parse(NewTextFileList[1]);
                    int NewRandomValue = numVall;
                    EveningContent = await _recipeService.GetRecipeById(NewRandomValue);
                    RaisePropertyChanged(() => EveningContent);
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
                EveningContent = await _recipeService.GetRecipeById(NewRandomValue);
                RaisePropertyChanged(() => EveningContent);
            }

        }


        private MvxCommand<Recipe> _navigateToEveningJuice;
        public MvxCommand<Recipe> NavigateToEveningJuice
        {
            get
            {
                if (_navigateToEveningJuice == null)
                    _navigateToEveningJuice = new MvxCommand<Recipe>(DoNavigateToEveningJuice);
                return _navigateToEveningJuice;
            }
        }

        private void DoNavigateToEveningJuice(Recipe selectedRecipe)
        {
            var _folderName = "TextFilesFolder3";
            var _fileName = "EveningJuice";
            string value = string.Empty;
            _fileStore.TryReadTextFile(_folderName + "/" + _fileName, out (value));
            string fV = value;

            List<string> TextFileList = new List<string>(
                fV.Split(new string[] { "," }, StringSplitOptions.None));
            int numVall = Int32.Parse(TextFileList[1]);
            int NewRandomValue = numVall;

            ShowViewModel<DetailJuiceListViewModel>(new { RecipeId = NewRandomValue });
        }

    }
}
