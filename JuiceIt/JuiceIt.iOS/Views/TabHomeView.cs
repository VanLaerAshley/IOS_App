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
            set.Bind(MorningImage).For(img => img.Image).To(res => res.MorningContent.picture).WithConversion<StringToImageConverter>();
            set.Bind(MorningJuiceName).To(vm => vm.MorningContent.name);
            set.Bind(MorningBtn)
               .To(vm => vm.NavigateToMorningJuice);

            set.Bind(AfternoonImage).For(img => img.Image).To(res => res.AfternoonContent.picture).WithConversion<StringToImageConverter>();
            set.Bind(AfternoonJuiceName).To(vm => vm.AfternoonContent.name);
            set.Bind(AfternoonBtn)
               .To(vm => vm.NavigateToAfternoonJuice);

            set.Bind(EveningImage).For(img => img.Image).To(res => res.EveningContent.picture).WithConversion<StringToImageConverter>();
            set.Bind(EveningJuiceName).To(vm => vm.EveningContent.name);
            set.Bind(EveningBtn)
               .To(vm => vm.NavigateToEveningJuice);
            set.Apply();
        }

        public override void ViewWillAppear(Boolean animated)
        {
            base.ViewWillAppear(animated);
            NavigationController.NavigationBar.PrefersLargeTitles = true;
        }
    }
}