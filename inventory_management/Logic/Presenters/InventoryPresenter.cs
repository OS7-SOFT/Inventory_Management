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
    public class InventoryPresenter
    {

        IInventoryView view;
        BindingSource inventoryList;

        InventoryModel model = new InventoryModel();

        //Constructor
        public InventoryPresenter(IInventoryView view)
        {
            inventoryList = new BindingSource();
            this.view = view;
            this.view.AddEvent += AddMethod;
            this.view.EditEvent += LoadDataToEdit;
            this.view.DeleteEvent += DeleteInventory;
            this.view.SaveEvent += SaveChange;
            this.view.CancelEvent += CancelMethod;
            this.view.GetDataList = inventoryList;
            //load all data
            LoadData();
        }

        private void ConnectionModelWithView()
        {
            model.Name = view.InventoryName;
            model.Capacity = view.InventoryCapacity;
            model.Location = view.InventoryLocation;
            model.CategoryName = view.CategoryName;
        }

        private void LoadData()
        {
            //Set data in inventoryList from database


            //Set all Categories
            //view.CategoryList.AddRange();

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
            view.Message = "Inventory deleted successfully";
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
                       
                        view.Message = "Inventory Edited Successfully";
                    }
                    else
                    {
                        //Add Category name Method 
                       
                        view.Message = "Inventory Added Successfully";
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
            view.InventoryName = "";
            view.InventoryLocation = "";
            view.InventoryCapacity = 0;
            view.CategoryName = "";
        }


        private bool CheckInput()
        {
            if (view.InventoryName.Trim() == "" || view.InventoryLocation == "" || view.InventoryCapacity == 0) 
            {
                
                return false;
            }

            return true;
        }
    }
}
