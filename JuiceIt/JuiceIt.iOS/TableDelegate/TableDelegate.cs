using System;
using System.Collections.Generic;
using System.Diagnostics;
using Foundation;
using JuiceIt.iOS.Views;
using JuiceIt.Shared.Models;
using JuiceIt.Shared.ViewModels;
using MvvmCross.iOS.Views;
using ObjCRuntime;
using SQLite;
using UIKit;

public class TableDelegate : UITableViewDelegate
{
    #region Private Variables
    private TabShopListView Controller;
    #endregion

    #region Constructors
   
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
    int counter = 0;
    private string dbPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "ShopzzList.db3");
    public override void WillDisplay(UITableView tableView, UITableViewCell tableViewCell, NSIndexPath indexPath)
    {
        List<string> ingredients = new List<string>();
        var db = new SQLiteConnection(dbPath);
        var databaseIngredients = db.Query<ShopList>($"select * from ShopList");
        var AmountOfData = databaseIngredients.Count;


        while (AmountOfData > counter)
        {
            var ingredient = databaseIngredients[counter].Ingredients;
            Controller.SendDataToWatch(ingredient);
            counter += 1;
        }

    }


    #endregion
}