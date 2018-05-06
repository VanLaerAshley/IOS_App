using System;
using System.Collections.Generic;
using Foundation;
using JuiceIt.iOS.Views;
using MvvmCross.iOS.Views;
using ObjCRuntime;
using UIKit;

public class TableDelegate : UITableViewDelegate
{
    #region Private Variables
    private TabShopListView Controller;
    #endregion

    #region Constructors
    public TableDelegate(UITableView tableView, Foundation.NSIndexPath indexPath)
    {
    }

    public TableDelegate(TabShopListView controller)
    {
        // Initialize
        this.Controller = controller;
    }
    #endregion

    #region Override Methods
    public override nfloat EstimatedHeight(UITableView tableView, Foundation.NSIndexPath indexPath)
    {
        return 44f;
    }


    public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
    {
        var cell = tableView.CellAt(indexPath) as ShopListViewCell;
        Controller.SendDataToWatch(cell.CheckListItem.Text);
	}

    #endregion
}