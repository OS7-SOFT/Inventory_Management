using DevExpress.DashboardWin.Design;
using DevExpress.XtraBars.ToastNotifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_management.Views.Forms.Notification
{
    internal class NotificationManger
    {
        private static NotificationManger Object;
        private ToastNotificationsManager toastNotificationsManager = new ToastNotificationsManager();
        private ToastNotification notification = new ToastNotification();
        public static NotificationManger Instance()
        {
            if(Object == null)
            {
                Object = new NotificationManger();
            }
            return Object;
        }
        
        public void AddNotification(string message,string id)
        {
            notification.Template = ToastNotificationTemplate.ImageAndText02;
            notification.Header = "Successfully Added";
            notification.Body = message;
            notification.ID = id;
            toastNotificationsManager.ShowNotification(notification);
        }

    }
}
