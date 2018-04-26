using System;
using JuiceIt.iOS.TableViewSources;
using JuiceIt.Shared.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;

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

            set.Bind(_favoriteViewSource).For(s => s.RemoveRowCommand).To(vm => vm.RemoveFavoriteCommand);
            set.Apply();
        }
    }
}