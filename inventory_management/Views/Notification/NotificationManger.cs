using DevExpress.DashboardWin.Design;
using DevExpress.XtraBars.ToastNotifications;
using DevExpress.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using DevExpress.DashboardWin.Native;

namespace inventory_management.Views.Forms.Notification
{
    internal class NotificationManger
    {
        private static NotificationManger Object;
        private ToastNotificationsManager toastNotificationsManager = new ToastNotificationsManager();
        private ToastNotification notification = new ToastNotification();
        public static NotificationManger Instance()
        {
            if (Object == null)
            {
                Object = new NotificationManger();
            }
            return Object;
        }

        public void AddNotification(string header,string message, string id)
        {


            notification.Template = ToastNotificationTemplate.ImageAndText02;
            notification.Header = header;
            notification.Body = message;
            notification.Sound = ToastNotificationSound.IM;
            notification.ID = id;
            notification.Image = ImageHelper.GetImage("images/actions/apply_32x32.png");
            

            toastNotificationsManager.ShowNotification(notification);
        }


    }
}
