using System;
using System.Globalization;
using Foundation;
using MvvmCross.Platform.Converters;
using UIKit;

namespace JuiceIt.iOS.Converters
{
    public class StringToImageConverter: MvxValueConverter<string, UIImage>
    {
        protected override UIImage Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            return GetOnlineImage(value);
        }

        private UIImage GetOnlineImage(string uri)
        {
            if (string.IsNullOrWhiteSpace(uri)) return null;
            using (var url = new NSUrl(uri))
            using (var data = NSData.FromUrl(url))
                return UIImage.LoadFromData(data);

        }
    }
}
