using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace JuiceIt.Core.ViewModels
{
    public class JuiceItTabsViewModel : MvxViewModel
    {
        //create a lazy instance for each viewmodel of the tabs in the tabview
        private readonly Lazy<TabHomeViewModel> _tabHomeViewModel;
        private readonly Lazy<TabIndexViewModel> _tabIndexViewModel;
        private readonly Lazy<TabFavoriteViewModel> _tabFavoriteViewModel;
        private readonly Lazy<TabShopListViewModel> _tabShopListViewModel;


        //property to acces value of the lazy instance
        public TabHomeViewModel TabHomeVM => _tabHomeViewModel.Value;
        public TabIndexViewModel TabIndexVM => _tabIndexViewModel.Value;
        public TabFavoriteViewModel TabFavoriteVM => _tabFavoriteViewModel.Value;
        public TabShopListViewModel TabShopListVM => _tabShopListViewModel.Value;


        public JuiceItTabsViewModel()
        {
            _tabHomeViewModel = new Lazy<TabHomeViewModel>(Mvx.IocConstruct<TabHomeViewModel>);
            _tabIndexViewModel = new Lazy<TabIndexViewModel>(Mvx.IocConstruct<TabIndexViewModel>);
            _tabFavoriteViewModel = new Lazy<TabFavoriteViewModel>(Mvx.IocConstruct<TabFavoriteViewModel>);
            _tabShopListViewModel = new Lazy<TabShopListViewModel>(Mvx.IocConstruct<TabShopListViewModel>);
        }
    }
}
