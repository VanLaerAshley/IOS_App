using Foundation;
using JuiceIt.iOS.SessionManager;
using JuiceIt.iOS.TableViewSources;
using JuiceIt.Shared.Models;
using JuiceIt.Shared.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using SaturdayMP.XPlugins.iOS;
using SQLite;
using System;
using System.Collections.Generic;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace JuiceIt.iOS.Views
{
    public partial class ShopListViewCell : MvxTableViewCell
    {
        internal static readonly NSString Identifier = new NSString("ShopListViewCell");
        public ShopListViewCell (IntPtr handle) : base (handle)
        {
        }
       
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
;

            var checkbox = new BEMCheckBox(new CoreGraphics.CGRect(9, 9, 27, 27));
            checkbox.OnCheckColor = Color.FromHex("97BD57").ToUIColor();
            checkbox.OnTintColor = Color.FromHex("97BD57").ToUIColor();
            checkbox.OnAnimationType = BEMAnimationType.Fill;
            checkbox.OffAnimationType = BEMAnimationType.Fill;
            checkbox.AnimationDidStopForCheckBox += CheckBoxClickedEvent;
            //ShopList shop = new ShopList();
            //while (shop != null)
            //{
            //    if (shop.checker == 0)
            //    {
            //        checkbox.On = false;
            //    }
            //    else
            //    {
            //        checkbox.On = true;

            //    }
            //    shop = null;
            //}

            CheckBox.AddSubview(checkbox);

            MvxFluentBindingDescriptionSet<ShopListViewCell, ShopList> set = new MvxFluentBindingDescriptionSet<ShopListViewCell, ShopList>(this);
            set.Bind(CheckListItem).To(res => res.Ingredients);
            set.Apply();

        }

        public void CheckBoxClickedEvent(object sender, EventArgs eventArg)
        {
            
            var checkbox = sender as BEMCheckBox;
            if (checkbox == null)
                return;
        }


    }
}