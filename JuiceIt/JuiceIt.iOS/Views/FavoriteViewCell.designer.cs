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
    [Register ("FavoriteViewCell")]
    partial class FavoriteViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SubtitleFavorite { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TitleFavorite { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (SubtitleFavorite != null) {
                SubtitleFavorite.Dispose ();
                SubtitleFavorite = null;
            }

            if (TitleFavorite != null) {
                TitleFavorite.Dispose ();
                TitleFavorite = null;
            }
        }
    }
}