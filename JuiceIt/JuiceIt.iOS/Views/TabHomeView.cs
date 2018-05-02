using JuiceIt.iOS.Converters;
using JuiceIt.Shared.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using System;
using UIKit;

namespace JuiceIt.iOS.Views
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class TabHomeView : MvxViewController<TabHomeViewModel>
    {
        public TabHomeView (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            MvxFluentBindingDescriptionSet<TabHomeView, TabHomeViewModel> set = new MvxFluentBindingDescriptionSet<TabHomeView, TabHomeViewModel>(this);
            set.Bind(image).For(img => img.Image).To(res => res.RecipeContent.picture).WithConversion<StringToImageConverter>();
            set.Bind(JuiceName).To(vm => vm.RecipeContent.name);
            set.Bind(RandomJuiceBtn)
               .To(vm => vm.NavigateToDetailCommand);
            set.Apply();
        }

        public override void ViewWillAppear(Boolean animated)
        {
            base.ViewWillAppear(animated);
            NavigationController.NavigationBar.PrefersLargeTitles = true;
        }
    }
}