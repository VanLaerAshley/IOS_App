using Foundation;
using JuiceIt.iOS.Converters;
using JuiceIt.Shared.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using System;
using UIKit;

namespace JuiceIt.iOS.Views
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class DetailFavoriteView : MvxViewController<DetailFavoriteViewModel>
    {
        public DetailFavoriteView (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationItem.LargeTitleDisplayMode = UINavigationItemLargeTitleDisplayMode.Never;

            MvxFluentBindingDescriptionSet<DetailFavoriteView, DetailFavoriteViewModel> set = new MvxFluentBindingDescriptionSet<DetailFavoriteView, DetailFavoriteViewModel>(this);
            set.Bind(NameRecipe).To(res => res.FavoriteContent.name);
            set.Bind(DetailImage).For(img => img.Image).To(res => res.FavoriteContent.thumbnail).WithConversion<StringToImageConverter>();
            set.Bind(DescriptionText).To(res => res.FavoriteContent.description);
            set.Bind(IngredientsList).To(res => res.Ingredients);
            set.Bind(ConditionText).To(res => res.Conditions);
            set.Bind(ButtonShopList).To(res => res.PostShopListCommand);
            set.Apply();
        }

        partial void ButtonShopList_TouchUpInside(UIButton sender)
        {
            UIAlertView alert = new UIAlertView()
            {
                Title = "Added to Shopping List"
            };
            alert.AddButton("OK");
            alert.Show();
        }
    }
}