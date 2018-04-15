using Foundation;
using MvvmCross.iOS.Views;
using System;
using UIKit;

namespace JuiceIt.iOS.Views
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class TabFavoriteView : MvxTableViewController
    {
        public TabFavoriteView (IntPtr handle) : base (handle)
        {
        }
    }
}