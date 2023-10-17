using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_management.Views.Forms.Notification
{
    public class NotifayIconSingleton 
    {
        private static NotifayIconSingleton instance;
        private NotifyIcon notifyIcon;

        private NotifayIconSingleton()
        {
            notifyIcon = new NotifyIcon();
        }

        public static NotifayIconSingleton Instance
        {
            get
            {
                if(instance == null)
                    instance = new NotifayIconSingleton();
                return instance;
            }
        }

        public NotifyIcon NotifyIcon { get { return notifyIcon; } }

    }
}
