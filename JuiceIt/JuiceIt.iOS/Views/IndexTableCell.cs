using Foundation;
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

            MvxFluentBindingDescriptionSet<IndexTableCell, Recipe> set = new MvxFluentBindingDescriptionSet<IndexTableCell, Recipe>(this);
            set.Bind(TitleRecipe).To(res => res.name);

            set.Bind(SubtitleRecipe).To(res => res.description);
            set.Apply();
        }



    }
}