using Foundation;
using MvvmCross.iOS.Views;
using System;
using UIKit;

namespace JuiceIt.iOS.Views
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class TabHomeView : MvxViewController
    {
        public TabHomeView (IntPtr handle) : base (handle)
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