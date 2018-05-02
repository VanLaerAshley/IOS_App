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
    [Register ("ShopListViewCell")]
    partial class ShopListViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton CheckBox { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel CheckListItem { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CheckBox != null) {
                CheckBox.Dispose ();
                CheckBox = null;
            }

            if (CheckListItem != null) {
                CheckListItem.Dispose ();
                CheckListItem = null;
            }
        }
    }
}