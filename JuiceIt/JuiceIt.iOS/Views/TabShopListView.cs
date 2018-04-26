using Foundation;
using MvvmCross.iOS.Views;
using System;
using UIKit;

namespace JuiceIt.iOS.Views
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class TabShopListView : MvxTableViewController
    {
        public TabShopListView (IntPtr handle) : base (handle)
        {
        }
    }
}