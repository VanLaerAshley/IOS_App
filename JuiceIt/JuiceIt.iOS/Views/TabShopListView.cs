using CoreGraphics;
using Foundation;
using JuiceIt.iOS.SessionManager;
using JuiceIt.iOS.TableViewSources;
using JuiceIt.Shared.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using System;
using System.Collections.Generic;
using UIKit;
using WatchConnectivity;

namespace JuiceIt.iOS.Views
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class TabShopListView : MvxTableViewController<TabShopListViewModel>
    {
        public TabShopListView (IntPtr handle) : base (handle)
        {
        }
        private TabShopListView Controller;
        public TabShopListView(TabShopListView controller)
        {
            // Initialize
            this.Controller = controller;
        }
        private ShopListViewSource _shopListViewSource;
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _shopListViewSource = new ShopListViewSource(this.TableView);
            this.TableView.Source = _shopListViewSource;
            this.TableView.Delegate = new TableDelegate(this);
            this.TableView.ReloadData();

            MvxFluentBindingDescriptionSet<TabShopListView, TabShopListViewModel> set = new MvxFluentBindingDescriptionSet<TabShopListView, TabShopListViewModel>(this);
            set.Bind(_shopListViewSource).To(vm => vm.ShopList);


            set.Bind(_shopListViewSource).For(s => s.RemoveRowCommand).To(vm => vm.RemoveShopListItemCommand);
            set.Apply();
        }

        public void SendDataToWatch(string ingredient)
        {
            
            WCSessionManager.SharedManager.UpdateApplicationContext(new Dictionary<string, object>() { { "MessagePhone", $"{ingredient}" } });
           
        }

	}
}