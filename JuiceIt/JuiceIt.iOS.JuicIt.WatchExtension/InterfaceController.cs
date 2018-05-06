﻿using System;
using WatchKit;
using Foundation;
using System.Collections.Generic;
using WatchConnectivity;

namespace JuiceIt.iOS.JuicIt.WatchExtension
{
    public partial class InterfaceController : WKInterfaceController
    {
        
        List<string> rows = new List<string>();
        protected InterfaceController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void Awake(NSObject context)
        {
            base.Awake(context);
            // Configure interface objects here.

            Console.WriteLine("{0} awake with context", this);
            WCSessionManager.SharedManager.ApplicationContextUpdated += DidReceiveApplicationContext;
        }

        public override void WillActivate()
        {
            // This method is called when the watch view controller is about to be visible to the user.

            Console.WriteLine("{0} will activate", this);

        }

        public override void DidDeactivate()
        {
            // This method is called when the watch view controller is no longer visible to the user.
            Console.WriteLine("{0} did deactivate", this);
            WCSessionManager.SharedManager.ApplicationContextUpdated -= DidReceiveApplicationContext;
        }
        void LoadTableRows()
        {

            MyTable.SetNumberOfRows((nint)rows.Count, "default");
            //MyTable.SetRowTypes (new [] {"default", "type1", "type2", "default", "default"});
            // Create all of the table rows.
            for (var i = 0; i < rows.Count; i++)
            {
                var elementRow = (ShopListCell)MyTable.GetRowController(i);

                elementRow.MyLabel.SetText(rows[i]);
            }

        }
        public void DidReceiveApplicationContext(WCSession session, Dictionary<string, object> applicationContext)
        {
            var message = (string)applicationContext["MessagePhone"];
            if (message != null)
            {
                Console.WriteLine($"Application context update received : {message}");
                rows.Add($"{message}");
                LoadTableRows();
            }

        }



        public override NSObject GetContextForSegue(string segueIdentifier, WKInterfaceTable table, nint rowIndex)
        {
            return new NSString(rows[(int)rowIndex]);
        }


        public override void DidSelectRow(WKInterfaceTable table, nint rowIndex)
        {
            var rowData = rows[(int)rowIndex];
            //PushController ("", );
            Console.WriteLine("Row selected:" + rowData);
        }
    }
}
