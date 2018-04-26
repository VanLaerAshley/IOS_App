using Foundation;
using JuiceIt.Shared.ViewModels;
using MvvmCross.Binding.BindingContext;
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
    }
}