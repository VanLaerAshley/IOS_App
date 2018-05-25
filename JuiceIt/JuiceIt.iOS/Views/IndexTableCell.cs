using CoreGraphics;
using Foundation;
using JuiceIt.iOS.Converters;
using JuiceIt.Shared.Models;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using System;
using UIKit;

namespace JuiceIt.iOS.Views
{
    public partial class IndexTableCell : MvxTableViewCell
    {
        internal static readonly NSString Identifier = new NSString("IndexTableCell");
        public IndexTableCell (IntPtr handle) : base (handle)
        {
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            var searchController = new UISearchController(searchResultsController: null);
            try
            {
                MvxFluentBindingDescriptionSet<IndexTableCell, Recipe> set = new MvxFluentBindingDescriptionSet<IndexTableCell, Recipe>(this);
                set.Bind(TitleRecipe).To(res => res.name);
                set.Bind(SubtitleRecipe).To(res => res.description);
                set.Bind(ThumbnailPicture).For(img => img.Image).To(res => res.thumbnail).WithConversion<StringToImageConverter>();

                set.Apply();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }



    }
}