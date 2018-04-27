using Foundation;
using JuiceIt.iOS.TableViewSources;
using JuiceIt.Shared.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using System;

namespace JuiceIt.iOS.Views
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class TabShopListView : MvxTableViewController<TabShopListViewModel>
    {
        public TabShopListView (IntPtr handle) : base (handle)
        {
        }

        private ShopListViewSource _shopListViewSource;
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _shopListViewSource = new ShopListViewSource(this.TableView);
            this.TableView.Source = _shopListViewSource;
            this.TableView.ReloadData();

            MvxFluentBindingDescriptionSet<TabShopListView, TabShopListViewModel> set = new MvxFluentBindingDescriptionSet<TabShopListView, TabShopListViewModel>(this);
            set.Bind(_shopListViewSource).To(vm => vm.ShopList);

            set.Bind(_shopListViewSource).For(s => s.RemoveRowCommand).To(vm => vm.RemoveShopListItemCommand);
            set.Apply();
        }
    }
}