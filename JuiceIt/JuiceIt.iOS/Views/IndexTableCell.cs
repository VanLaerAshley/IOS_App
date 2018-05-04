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

            //var shadowPath = new CAShapeLayer();
            //shadowPath = new UIBezierPath(ThumbnailPicture.Bounds).CGPath;
            //UIBezierPath shadowPath = new UIBezierPath( bezierPathWithRect: ThumbnailPicture.Bounds);
            //ThumbnailPicture.Layer.MasksToBounds = false;
            //ThumbnailPicture.Layer.ShadowColor = UIColor.DarkGray.CGColor;
            //ThumbnailPicture.Layer.ShadowOffset = new CGSize(0.0f, 5.0f);
            //ThumbnailPicture.Layer.ShadowOpacity = 0.5f;
            //ThumbnailPicture.Layer.ShadowPath = ;

            this.Layer.MasksToBounds = false;
            this.Layer.CornerRadius = 10;
            this.Layer.ShadowColor = UIColor.DarkGray.CGColor;
            this.Layer.ShadowOpacity = 1.0f;
            this.Layer.ShadowRadius = 6.0f;
            this.Layer.ShadowOffset = new System.Drawing.SizeF(0f, 3f);


            MvxFluentBindingDescriptionSet<IndexTableCell, Recipe> set = new MvxFluentBindingDescriptionSet<IndexTableCell, Recipe>(this);
            set.Bind(TitleRecipe).To(res => res.name);
            set.Bind(SubtitleRecipe).To(res => res.description);
            set.Bind(ThumbnailPicture).For(img => img.Image).To(res => res.thumbnail).WithConversion<StringToImageConverter>();

            set.Apply();
        }



    }
}