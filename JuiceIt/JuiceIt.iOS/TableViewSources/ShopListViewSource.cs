using System;
using Foundation;
using JuiceIt.iOS.Views;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Core.ViewModels;
using UIKit;

namespace JuiceIt.iOS.TableViewSources
{
    public class ShopListViewSource : MvxTableViewSource
    {
        
        public ShopListViewSource(UITableView tableView) : base(tableView)
        {
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            try
            {
                var cell = (ShopListViewCell)tableView.DequeueReusableCell(ShopListViewCell.Identifier, indexPath);
                return cell;
            }
            catch (Exception ex)
            {
                //Crashes.TrackError(ex);
                return null;
            }
        }
        public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
        {
            return true;
        }

        public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
        {
            switch (editingStyle)
            {
                case UITableViewCellEditingStyle.Delete:
                    RemoveRowCommand.Execute(indexPath.Row);
                    break;
                case UITableViewCellEditingStyle.None:
                    break;
            }
        }

        public IMvxCommand RemoveRowCommand { get; set; }

        public IMvxCommand RemoveAllCommand { get; set; }

    }
}
