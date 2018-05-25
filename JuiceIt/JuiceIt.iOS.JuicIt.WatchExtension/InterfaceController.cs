using System;
using WatchKit;
using Foundation;
using System.Collections.Generic;
using WatchConnectivity;
using System.Linq;
using System.Diagnostics;
using JuiceIt.iOS.JuicIt.WatchExtension.SessionManager;

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

            LoadTableRows();
        }

        public override void DidDeactivate()
        {
            // This method is called when the watch view controller is no longer visible to the user.
            Console.WriteLine("{0} did deactivate", this);
            //WCSessionManager.SharedManager.ApplicationContextUpdated -= DidReceiveApplicationContext;
        }

        void LoadTableRows()
        {
            
            MyTable.SetNumberOfRows((nint)rows.Count, "default");
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
                if(rows.Contains(message))
                {
                    LoadTableRows();
                }
                else
                {
                    rows.Add(message);
                    LoadTableRows();
                }
            }
        }

        public override void DidSelectRow(WKInterfaceTable table, nint rowIndex)
        {
            rows.RemoveAt((int)rowIndex);
            LoadTableRows();
           
        }
    }
}
