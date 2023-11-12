using inventory_management.Logic.Presenters;
using inventory_management.Views.Interfaces;
using inventory_management.Views.Notification;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_management.Views.Forms.Home
{
    internal class Home:IHomeView
    {
        HomePresenters homePresenters;

        //fildes 
        public BindingSource FullInventory;
        public BindingSource ExpiredProduct;




        //Constructor
        public Home()
        {
            homePresenters = new HomePresenters(this);
        }


        public BindingSource GetFullInventoryList { set => FullInventory = value; }
        public BindingSource GetExpiredProductsList { set => ExpiredProduct = value; }


        public event EventHandler LoadDataEvent;


        public void LoadData()
        {
            LoadDataEvent?.Invoke(this, EventArgs.Empty);
        }

        //Singleton
        private static Home Object = null;
        public static Home Instance()
        {
            if (Object == null)
                Object = new Home();
            return Object;
        }
    }
}
