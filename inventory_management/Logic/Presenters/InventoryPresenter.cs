using inventory_management.Logic.Services;
using inventory_management.Models;
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
    public class InventoryPresenter
    {

        IInventoryView view;
        BindingSource inventoryList;
        BindingSource CategoryList;
        private object[] Params;

        InventoryModel model = new InventoryModel();
        InventoryServices inventoryServices = new InventoryServices();
        //Constructor
        public InventoryPresenter(IInventoryView view)
        {
            inventoryList = new BindingSource();
            CategoryList = new BindingSource();
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
            inventoryList.DataSource = inventoryServices.GetData();

            //Set all inventories
            DataTable dt = inventoryServices.GetComboBoxData();
            List<string> data = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                data.Add(dt.Rows[i][0].ToString());
            }
            view.CategoryList = data.ToList();

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
            DataTable dt = inventoryServices.GetDataByValue(model.Id);
            view.InventoryName = dt.Rows[0][0].ToString();
            view.InventoryLocation = dt.Rows[0][1].ToString();
            view.CategoryName = dt.Rows[0][2].ToString();
            view.InventoryCapacity = Convert.ToDouble(dt.Rows[0][3]);
        }

        private void DeleteInventory(object sender, EventArgs e)
        {
            model.Id = view.Id;

            //delete Inventory
            inventoryServices.DeleteData(model.Id);
            view.Message = $"{view.InventoryName} Inventory deleted successfully";
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
                        Params = new object[5];
                        Params[0] = model.Id;
                        Params[1] = model.Name;
                        Params[2] = inventoryServices.GetDataByValue(model.CategoryName).Rows[0][0]; ;
                        Params[3] = model.Location;
                        Params[4] = model.Capacity;
                        inventoryServices.EditData(Params);
                        view.Message = $"{view.InventoryName} Inventory Edited Successfully";
                    }
                    else
                    {
                        //Add inventory name Method 
                        Params = new object[4];
                        Params[0] = model.Name;
                        Params[1] = inventoryServices.GetDataByValue(model.CategoryName).Rows[0][0];
                        Params[2] = model.Location;
                        Params[3] = model.Capacity;
                        inventoryServices.AddData(Params);
                        view.Message = $"{view.InventoryName}Inventory Added Successfully";
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
            if (view.InventoryName.Trim() == "" || view.InventoryLocation == "" || view.InventoryCapacity == 0 || view.CategoryName == "")
            {

                return false;
            }

            return true;
        }
    }
}
