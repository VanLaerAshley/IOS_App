using Foundation;
using JuiceIt.Shared.Models;
using JuiceIt.Shared.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using SaturdayMP.XPlugins.iOS;
using System;
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

            //var bemCheckBoxLabel = new UILabel()
            //{
            //    Frame = new CoreGraphics.CGRect(0, 0, 0, 0)
            //};


            var checkbox = new BEMCheckBox(new CoreGraphics.CGRect(9, 9, 27, 27));
            checkbox.OnCheckColor = Color.FromHex("97BD57").ToUIColor();
            checkbox.OnTintColor = Color.FromHex("97BD57").ToUIColor();
            checkbox.AnimationDidStopForCheckBox += CheckBoxClickedEvent;
            //ShopList shop = new ShopList();
            //while(shop != null)
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
            //set.Bind(CheckBox).To(vm => vm.PostCheckCommand);
            set.Apply();

        }

        private void CheckBoxClickedEvent(object sender, EventArgs eventArgs)
        {
            var checkbox = sender as BEMCheckBox;
            if (checkbox != null)
            {
                Console.WriteLine("checkbox is gelijk aan nul dus unchecked");
                //MvxFluentBindingDescriptionSet<ShopListViewCell, TabShopListViewModel> set = new MvxFluentBindingDescriptionSet<ShopListViewCell, TabShopListViewModel>(this);
                //set.Bind(CheckBox).To(vm => vm.PostCheckCommand);
                //set.Apply();
            }
            else
            {
                Console.WriteLine("checkbox is NIET gelijk aan nul dus checked");    
            }

            // Do what you need to do with the checkbox.
        }
    }
}