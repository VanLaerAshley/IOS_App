using System;
using System.Collections.Generic;
using System.Windows.Input;
using JuiceIt.Shared.Models;
using JuiceIt.Shared.Services;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace JuiceIt.Shared.ViewModels
{
    public class TabShopListViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private ILocalShopListService _localShopListService;
        public TabShopListViewModel(ILocalShopListService localShopListService, IMvxNavigationService navigationService)
        {
            this._navigationService = navigationService;
            this._localShopListService = localShopListService;
            GetShopList();
        }

        private List<ShopList> _shopList;

        public List<ShopList> ShopList
        {
            get
            {
                return _shopList;
            }
            set
            {
                _shopList = value;
                RaisePropertyChanged(() => ShopList);
            }
        }

        private ShopList _shopItems;

        public ShopList ShopItems
        {
            get
            {
                return _shopItems;
            }
            set
            {
                _shopItems = value;
                RaisePropertyChanged(() => ShopItems);
            }
        }

        public async void GetShopList()
        {
            ShopList = await _localShopListService.GetShopList();
        }

        public async void GetShopListAgain()
        {
            ShopList = await _localShopListService.GetShopListAgain();
        }

        public IMvxCommand RemoveShopListItemCommand
        {
            get
            {
                return new MvxCommand<int>(RemoveShopListItem);
            }
        }

        public void RemoveShopListItem(int index)
        {
            ShopList f = ShopList[index];
            _localShopListService.DeleteShopListItem(f.Id);
            GetShopListAgain();

        }
        public  override void ViewAppearing()
        {
            base.ViewAppearing();
            GetShopList();
        }


        public ICommand PostCheckCommand
        {
            get
            {
                return new MvxCommand(AddChecker);
            }
        }

        public void AddChecker()
        {
            _localShopListService.AddShopListChecker();
            _navigationService.Navigate<TabShopListViewModel>();
        }


    }
}
