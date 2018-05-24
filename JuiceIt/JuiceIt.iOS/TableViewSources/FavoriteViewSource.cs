using System;
using Foundation;
using JuiceIt.iOS.Views;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Core.ViewModels;
using UIKit;

namespace JuiceIt.iOS.TableViewSources
{
    public class FavoriteViewSource : MvxTableViewSource
    {
        public FavoriteViewSource(UITableView tableView, string Identifier, int expandedHeight) : base(tableView)
        {
            expandedCellHeight = expandedHeight;
        }
        private int expandedCellHeight { get; set; }


        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return expandedCellHeight;
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            try
            {
                var cell = (FavoriteViewCell)tableView.DequeueReusableCell(FavoriteViewCell.Identifier, indexPath);
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

        public override bool CanMoveRow(UITableView tableView, NSIndexPath indexPath)
        {
            return true;
        }

        public override void MoveRow(UITableView tableView, NSIndexPath sourceIndexPath, NSIndexPath destinationIndexPath)
        {
            var deleteAt = sourceIndexPath.Row;
            var insertAt = destinationIndexPath.Row;
            if (destinationIndexPath.Row < sourceIndexPath.Row)
            {
                deleteAt += 1;
            }
            else
            {
                insertAt += 1;
            }

            ReorderCommand.Execute(new Tuple<int, int>(deleteAt, insertAt));
        }

        public IMvxCommand ReorderCommand { get; set; }

    }
}
