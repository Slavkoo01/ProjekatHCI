using Notification.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_HCI.Helper
{
    internal static class Toast
    {
        public static NotificationManager _notificationManager = new NotificationManager();
        public static void ShowToastNotification(ToastNotification toastNotification)
        {
            _notificationManager.Show(toastNotification.Title, toastNotification.Message, toastNotification.Type, "WindowNotificationArea");
        }
    }
}
