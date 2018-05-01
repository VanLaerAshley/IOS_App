using System;
using System.Collections.Generic;
using JuiceIt.Shared.Models;
using JuiceIt.Shared.Services;
using MvvmCross.Core.ViewModels;

namespace JuiceIt.Shared.ViewModels
{
    public class TabShopListViewModel : MvxViewModel
    {
        private ILocalShopListService _localShopListService;
        public TabShopListViewModel(ILocalShopListService localShopListService)
        {
            this._localShopListService = localShopListService;
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

        public async void GetShopList()
        {
            ShopList = await _localShopListService.GetShopList();
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
            GetShopList();

        }
        public override void ViewAppearing()
        {
            base.ViewAppearing();

            GetShopList();
        }
    }
}
