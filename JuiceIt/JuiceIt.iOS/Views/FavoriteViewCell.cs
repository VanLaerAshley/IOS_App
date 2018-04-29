using Foundation;
using JuiceIt.Shared.Models;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using System;
using UIKit;

namespace JuiceIt.iOS.Views
{
    public partial class FavoriteViewCell : MvxTableViewCell
    {
        internal static readonly NSString Identifier = new NSString("FavoriteViewCell");
        public FavoriteViewCell(IntPtr handle) : base(handle)
        {
        }
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            MvxFluentBindingDescriptionSet<FavoriteViewCell, Favorites> set = new MvxFluentBindingDescriptionSet<FavoriteViewCell, Favorites>(this);
            set.Bind(TitleFavorite).To(res => res.name);
            set.Bind(SubtitleFavorite).To(res => res.description);
            set.Apply();
        }
    }
}