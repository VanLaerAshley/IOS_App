using System;
using CoreAnimation;
using CoreGraphics;
using JuiceIt.Shared.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;

namespace JuiceIt.iOS
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class DetailJuiceListView : MvxViewController<DetailJuiceListViewModel>
    {
        public DetailJuiceListView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();



            MvxFluentBindingDescriptionSet<DetailJuiceListView, DetailJuiceListViewModel> set = new MvxFluentBindingDescriptionSet<DetailJuiceListView, DetailJuiceListViewModel>(this);
            set.Bind(NameRecipe).To(res => res.RecipeContent.name);
            set.Bind(DescriptionText).To(res => res.RecipeContent.description);
            set.Bind(IngredientsList).To(res => res.Ingredients);
            set.Bind(ConditionText).To(res => res.Conditions);
            set.Bind(ButtonFavorites).To(res => res.PostFavoriteCommand);
            set.Bind(ButtonShopList).To(res => res.PostShopListCommand);
            set.Apply();
        }

        partial void ButtonFavorites_TouchUpInside(UIButton sender)
        {
           
            UIAlertView alert = new UIAlertView()
            {
                Title = "Added to Favorites"
            };
            alert.AddButton("OK");
            alert.Show();

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