using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using FuelDashApp.Services;
using GlobalToast;
using UIKit;

namespace FuelDashApp.iOS.CustomRenderer
{
    public class MessageIOS : IMessage
    {
        const double LONG_DELAY = 2.5;
        const double SHORT_DELAY = 1.0;

        NSTimer alertDelay;
        UIAlertController alert;
        // UIAlertAction action;

        public void LongAlert(string message)
        {
            Toast.MakeToast(message).Show();
        }
        public void ShortAlert(string message)
        {
            Toast.MakeToast(message).Show();
        }

        void ShowAlert(string message, double seconds)
        {
            alertDelay = NSTimer.CreateScheduledTimer(seconds, (obj) =>
            {
                dismissMessage();
            });
            alert = UIAlertController.Create("", message, UIAlertControllerStyle.Alert);


            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);
        }
        void dismissMessage()
        {
            if (alert != null)
            {
                alert.DismissViewController(true, null);
            }
            if (alertDelay != null)
            {
                alertDelay.Dispose();
            }
        }

        public string GetPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
        }
    }
}