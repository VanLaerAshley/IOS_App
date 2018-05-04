// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace JuiceIt.iOS.Views
{
    [Register ("DetailFavoriteView")]
    partial class DetailFavoriteView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ButtonShopList { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ConditionText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DescriptionText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView DetailImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel IngredientsList { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel NameRecipe { get; set; }

        [Action ("ButtonShopList_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ButtonShopList_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (ButtonShopList != null) {
                ButtonShopList.Dispose ();
                ButtonShopList = null;
            }

            if (ConditionText != null) {
                ConditionText.Dispose ();
                ConditionText = null;
            }

            if (DescriptionText != null) {
                DescriptionText.Dispose ();
                DescriptionText = null;
            }

            if (DetailImage != null) {
                DetailImage.Dispose ();
                DetailImage = null;
            }

            if (IngredientsList != null) {
                IngredientsList.Dispose ();
                IngredientsList = null;
            }

            if (NameRecipe != null) {
                NameRecipe.Dispose ();
                NameRecipe = null;
            }
        }
    }
}