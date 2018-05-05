using Foundation;
using MvvmCross.Binding.iOS.Views;
using System;
using UIKit;

namespace JuiceIt.iOS
{
    public partial class TabHomeSubview : MvxView
    {
        public TabHomeSubview (IntPtr handle) : base (handle)
        {
        }

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();  

            this.Layer.MasksToBounds = false;
            this.Layer.CornerRadius = 15;
            this.Layer.ShadowColor = UIColor.DarkGray.CGColor;
            this.Layer.ShadowOpacity = .3f;
            this.Layer.ShadowRadius = 7.0f;
            this.Layer.ShadowOffset = new System.Drawing.SizeF(0f, 3f);
		}
	}
}