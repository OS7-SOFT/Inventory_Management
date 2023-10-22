using inventory_management.Models;
using inventory_management.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_management.Logic.Presenters
{
    public class OrderPresenter
    {
        IOrderView view;
        BindingSource orderList;

        OrderModel model = new OrderModel();
        //Constructor
        public OrderPresenter(IOrderView view)
        {
            orderList = new BindingSource();
            this.view = view;
            this.view.AddEvent += AddMethod;
            this.view.EditEvent += LoadDataToEdit;
            this.view.DeleteEvent += DeleteInventory;
            this.view.SaveEvent += SaveChange;
            this.view.CancelEvent += CancelMethod;
            this.view.GetDataList = orderList;
            //load all data
            LoadData();
        }

        private void ConnectionModelWithView()
        {
            model.OrderedQuantity = view.OrderedQuantity;
            model.DeliveryStatus = view.DeliveryStatus;
            model.OrderDate = view.OrderDate;
            model.CustomerName = view.CustomerName;
            model.ProductName = view.ProductName;
          
        }

        private void LoadData()
        {
            //Set data in inventoryList from database


            //Set all Categories


        }



        private void AddMethod(object sender, EventArgs e)
        {
            view.IsEdit = false;
        }

        private void LoadDataToEdit(object sender, EventArgs e)
        {
            view.IsEdit = true;
            model.Id = view.Id;

            //Get current inventory by id 
        }

        private void DeleteInventory(object sender, EventArgs e)
        {
            model.Id = view.Id;

            //delete Inventory

            view.Message = $"{view.Id} deleted successfully";
            view.IsSuccessed = true;
            LoadData();
        }

        private void SaveChange(object sender, EventArgs e)
        {
            view.IsSuccessed = false;

            if (CheckInput())
            {
                try
                {
                    ConnectionModelWithView();
                    if (view.IsEdit)
                    {
                        model.Id = view.Id;
                        //Edit InventoryMethod 

                        view.Message = $"{view.Id} Edited Successfully";
                    }
                    else
                    {
                        //Add Category name Method 

                        view.Message = $"{view.Id}  Added Successfully";
                    }

                    view.IsSuccessed = true;
                    LoadData();
                }
                catch (Exception ex)
                {
                    view.Message = ex.Message;
                }
            }
            else view.Message = "All feilds is required";
        }

        private void CancelMethod(object sender, EventArgs e)
        {
            view.OrderedQuantity = 0;

        }


        private bool CheckInput()
        {
            if (view.OrderedQuantity == 0)
            {

                return false;
            }

            return true;
        }
    }
}
