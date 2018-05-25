using JuiceIt.iOS.Converters;
using JuiceIt.Shared.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using System;
using UIKit;
using CoreGraphics;

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

            MorningStaticLabel.Layer.ShadowOpacity = .5f;
            MorningStaticLabel.Layer.ShadowRadius = 6;
			MorningStaticLabel.Layer.ShadowOffset = new CGSize(0, 0);
            MorningJuiceName.Layer.ShadowOpacity = .5f;
            MorningJuiceName.Layer.ShadowRadius = 6;
			MorningJuiceName.Layer.ShadowOffset = new CGSize(0, 0);

            AfternoonStaticLabel.Layer.ShadowOpacity = .5f;
            AfternoonStaticLabel.Layer.ShadowRadius = 6;
			AfternoonStaticLabel.Layer.ShadowOffset = new CGSize(0, 0);
            AfternoonJuiceName.Layer.ShadowOpacity = .5f;
            AfternoonJuiceName.Layer.ShadowRadius = 6;
			AfternoonJuiceName.Layer.ShadowOffset = new CGSize(0, 0);
            
            EveningStaticLabel.Layer.ShadowOpacity = .5f;
            EveningStaticLabel.Layer.ShadowRadius = 6;
			EveningStaticLabel.Layer.ShadowOffset = new CGSize(0, 0);
            EveningJuiceName.Layer.ShadowOpacity = .5f;
            EveningJuiceName.Layer.ShadowRadius = 6;
			EveningJuiceName.Layer.ShadowOffset = new CGSize(0, 0);
            try
            {
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
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public override void ViewWillAppear(Boolean animated)
        {
            base.ViewWillAppear(animated);
            NavigationController.NavigationBar.PrefersLargeTitles = true;
            NavigationController.NavigationBar.BarTintColor = UIColor.White;

            NavigationController.NavigationBar.ShadowImage = new UIImage();
        }
        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
           
            NavigationController.NavigationBar.ShadowImage = null;
        }
    }
}