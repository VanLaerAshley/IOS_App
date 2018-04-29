using Foundation;
using JuiceIt.Shared.Models;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using System;
using UIKit;

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

            MvxFluentBindingDescriptionSet<ShopListViewCell, ShopList> set = new MvxFluentBindingDescriptionSet<ShopListViewCell, ShopList>(this);
            set.Bind(TextLabel).To(res => res.Ingredients);
            set.Apply();
        }
    }
}