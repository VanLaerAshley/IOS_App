using Foundation;
using System;
using System.CodeDom.Compiler;

namespace JuiceIt.iOS.JuicIt.WatchExtension
{
    public partial class ShopListCell : NSObject
    {
        public ShopListCell (IntPtr handle) : base (handle)
        {
        }
		[Outlet]
        [GeneratedCode("iOS Designer", "1.0")]
        public WatchKit.WKInterfaceLabel MyLabel { get; set; }

        void ReleaseDesignerOutlets()
        {
            if (MyLabel != null)
            {
                MyLabel.Dispose();
                MyLabel = null;
            }
        }
    }
}