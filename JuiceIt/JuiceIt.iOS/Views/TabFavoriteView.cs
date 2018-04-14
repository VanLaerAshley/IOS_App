using Foundation;
using MvvmCross.iOS.Views;
using System;
using UIKit;

namespace JuiceIt.iOS
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class TabFavoriteView : MvxViewController
    {
        public TabFavoriteView (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {

            base.ViewDidLoad();


        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}