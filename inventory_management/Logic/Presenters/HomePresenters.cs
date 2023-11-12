using inventory_management.Logic.Services;
using inventory_management.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_management.Logic.Presenters
{
    public class HomePresenters
    {
        IHomeView view;
        BindingSource inventoryList;
        BindingSource productsList;


        HomeServices homeServices = new HomeServices();

        public HomePresenters(IHomeView view)
        {
            this.view = view;
            inventoryList = new BindingSource();
            productsList = new BindingSource();
            this.view.LoadDataEvent += LoadData;
        }

        private void LoadData(object sender, EventArgs e)
        {
            //Get full capicty inventory
           inventoryList.DataSource = homeServices.Getdata("FullandNearFullInventory");
            view.GetFullInventoryList = inventoryList;

            //Get expired products
            productsList.DataSource = homeServices.Getdata("ExpiredProducts");
            view.GetExpiredProductsList = productsList;
        }
    }
}
