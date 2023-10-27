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
        BindingSource categoryList;
        BindingSource productsList;

        private object[] Params;

        InventoryModel model = new InventoryModel();
        InventoryServices inventoryServices = new InventoryServices();
        //Constructor
        public InventoryPresenter(IInventoryView view)
        {
            inventoryList = new BindingSource();
            categoryList = new BindingSource();
            productsList = new BindingSource();
            this.view = view;
            this.view.AddEvent += AddMethod;
            this.view.EditEvent += LoadDataToEdit;
            this.view.DeleteEvent += DeleteInventory;
            this.view.SaveEvent += SaveChange;
            this.view.TransformEvent += TransferMethod;
            this.view.CancelEvent += CancelMethod;
            this.view.LoadDataEvent += LoadData;
            this.view.GetInventoryInfoEvent += GetCurrentInventoryInfo;
        }

        private void ConnectionModelWithView()
        {
            model.Name = view.InventoryName;
            model.Capacity = view.InventoryCapacity;
            model.Location = view.InventoryLocation;
            model.CategoryName = view.CategoryName;
        }

        private void LoadData(object sender, EventArgs e)
        {
            //Set data in inventoryList from database
            inventoryList.DataSource = inventoryServices.GetData();
            view.GetDataList = inventoryList; 
            categoryList.DataSource = inventoryServices.GetComboBoxData();
            view.CategoryList = ((DataTable)categoryList.DataSource).AsEnumerable()
                .SelectMany(row => row.ItemArray
                .Select(cell => cell.ToString()))
                .ToList();

        }

        private void GetCurrentInventoryInfo(object sender, EventArgs e)
        {
            model.Id = view.Id;
            //Set All products in current inventory 
            productsList.DataSource = inventoryServices.GetDataByValue(model.Id, "selectInventoryProducts");
            view.GetProducts = productsList;
            
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
            DataTable dt = inventoryServices.GetDataByValue(model.Id, "selectInventoryById");
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
       
        }

        private void TransferMethod(object sender, EventArgs e)
        {
            //set operation
            //--here--

            view.Message = "Products Transferd Successfully";
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
                        if (inventoryServices.GetDataByValue(model.CategoryName) == null)
                        {
                            Params[2] = null;
                        }
                        else
                        {
                            Params[2] = inventoryServices.GetDataByValue(model.CategoryName).Rows[0][0]; ;
                        }
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
                        if(inventoryServices.GetDataByValue(model.CategoryName) == null)
                        {
                            Params[1] =null;
                        }
                        else
                        {
                            Params[1] = inventoryServices.GetDataByValue(model.CategoryName).Rows[0][0]; ;
                        }
                        Params[2] = model.Location;
                        Params[3] = model.Capacity;
                        inventoryServices.AddData(Params);
                        view.Message = $"{view.InventoryName}Inventory Added Successfully";
                    }

                    view.IsSuccessed = true;
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
