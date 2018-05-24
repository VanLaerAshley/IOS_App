using System;
using Foundation;
using JuiceIt.iOS.Views;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace JuiceIt.iOS.TableViewSources
{
    public class RecipeViewSource : MvxTableViewSource
    {
		protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
		{
            try
            {
                var cell = (IndexTableCell)tableView.DequeueReusableCell(IndexTableCell.Identifier, indexPath);
                return cell;
            }
            catch (Exception ex)
            {
                //Crashes.TrackError(ex);
                return null;
            }
		}

        public RecipeViewSource(UITableView table, string Identifier, int expandedHeight) : base(table)
        {
            expandedCellHeight = expandedHeight;
        }
        private int expandedCellHeight { get; set; }


        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return expandedCellHeight;
        }
	}
}
