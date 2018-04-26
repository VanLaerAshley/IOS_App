using Foundation;
using JuiceIt.Shared.ViewModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using System;
using UIKit;

namespace JuiceIt.iOS.Views
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class JuiceItTabsView : MvxTabBarViewController<JuiceItTabsViewModel>
    {
        private bool _constructed;
        public JuiceItTabsView (IntPtr handle) : base (handle)
        {
            _constructed = true;
            ViewDidLoad();
        }

        public override void ViewDidLoad()
        {
            if (!_constructed) return;
            base.ViewDidLoad();

            //tabs aanmaken
            CreateTabs();
        }
        private void CreateTabs()
        {
            //voeg viewcontrollers toe voor elk tablad en bewaar
            var viewControllers = new UIViewController[]
            {
                CreateSingleTab("Home", ViewModel.TabHomeVM, UIImage.FromBundle("home")),
                CreateSingleTab("Search", ViewModel.TabIndexVM, UIImage.FromBundle("search")),
                CreateSingleTab("Favorites", ViewModel.TabFavoriteVM, UIImage.FromBundle("favorites")),
                CreateSingleTab("Shop List", ViewModel.TabShopListVM, UIImage.FromBundle("list"))
            };
            ViewControllers = viewControllers;
            //stel de eerste tab in als geselecteerd
            SelectedViewController = ViewControllers[0];

            //pas titel aan bij het selecteren van een tablad
            NavigationItem.Title = SelectedViewController.Title;

            ViewControllerSelected += (o, e) =>
            {
                NavigationItem.Title = TabBar.SelectedItem.Title;
            };
        }

        private UIViewController CreateSingleTab(string tabName, MvxViewModel tabViewModel, UIImage image)
        {
            //viewcontroller aanmaken adhv viewmodel
            var viewController =
                this.CreateViewControllerFor(tabViewModel) as UIViewController;
            tabViewModel.Start();

            //titel instellen op naam tablad
            viewController.Title = tabName;
            //UIImage Image = Image.Size(10)
            viewController.TabBarItem = new UITabBarItem() { Title = tabName, Image = image };

            return viewController;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}