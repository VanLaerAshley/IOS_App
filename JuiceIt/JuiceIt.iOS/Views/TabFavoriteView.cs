using System;
using JuiceIt.iOS.TableViewSources;
using JuiceIt.Shared.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;

namespace JuiceIt.iOS.Views
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class TabFavoriteView : MvxTableViewController<TabFavoriteViewModel>
    {
        public TabFavoriteView(IntPtr handle) : base(handle)
        {
        }

        private FavoriteViewSource _favoriteViewSource;
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _favoriteViewSource = new FavoriteViewSource(this.TableView, FavoriteViewCell.Identifier, 125);
            this.TableView.Source = _favoriteViewSource;
            this.TableView.ReloadData();

            MvxFluentBindingDescriptionSet<TabFavoriteView, TabFavoriteViewModel> set = new MvxFluentBindingDescriptionSet<TabFavoriteView, TabFavoriteViewModel>(this);
            set.Bind(_favoriteViewSource).To(vm => vm.Favorites);

            set.Bind(_favoriteViewSource)
               .For(src => src.SelectionChangedCommand)
               .To(vm => vm.NavigateToDetailCommand);

            set.Bind(_favoriteViewSource).For(s => s.ReorderCommand).To(vm => vm.Reorder);
            set.Bind(_favoriteViewSource).For(s => s.RemoveRowCommand).To(vm => vm.RemoveFavoriteCommand);

            set.Apply();
        }

        public override void ViewWillAppear(Boolean animated)
        {
            base.ViewWillAppear(animated);
            TabBarController.NavigationItem.RightBarButtonItem = EditButtonItem;
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            TabBarController.NavigationItem.RightBarButtonItem = null;
        }
    }
}
