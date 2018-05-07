
using System;
using System.Collections.Generic;
using JuiceIt.Shared.Models;
using JuiceIt.Shared.Services;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace JuiceIt.Shared.ViewModels
{
    public class TabFavoriteViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private ILocalDbService _localDbService;
        public TabFavoriteViewModel( ILocalDbService localDbService, IMvxNavigationService navigationService)
        {
            this._localDbService = localDbService;
            this._navigationService = navigationService;
            GetFavoriteData();
        }
        private List<Favorites> _favorites;

        public List<Favorites> Favorites
        {
            get
            {
                return _favorites;
            }
            set
            {
                _favorites = value;
                RaisePropertyChanged(() => Favorites);
            }
        }

        public async void GetFavoriteData()
        {
            Favorites = await _localDbService.GetFavorite();
        }

        public async void GetFavoriteAgain()
        {
            Favorites = await _localDbService.GetFavoriteAgain();
        }

        public IMvxCommand RemoveFavoriteCommand
        {
            get
            {
                return new MvxCommand<int>(RemoveFavorite);
            }
        }

        public void RemoveFavorite(int index)
        {
            Favorites f = Favorites[index];
            _localDbService.DeleteFavorite(f.id);
            GetFavoriteAgain();

        }
        public MvxCommand<Favorites> NavigateToDetailCommand
        {
            get
            {
                return new MvxCommand<Favorites>(selectedFavorite =>
                {
                    ShowViewModel<DetailFavoriteViewModel>(new { FavoriteId = selectedFavorite.id });
                });
            }
        }

        public IMvxCommand<Tuple<int, int>> Reorder
        {
            get
            {
                return new MvxCommand<Tuple<int, int>>(ReOrder);
            }
        }

        private void ReOrder(Tuple<int, int> positions)
        {
            var item = Favorites[positions.Item1];
            Favorites.Insert(positions.Item2, item);
            Favorites.RemoveAt(positions.Item1);
            RaisePropertyChanged(() => Favorites);
        }

        public override void ViewAppearing()
        {
            base.ViewAppearing();
            GetFavoriteData();
        }
	}
}