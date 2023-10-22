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
    public class SuppliersPresenter
    {
        ISuppliersView view;
        BindingSource supplierList;

        SupplierModel model = new SupplierModel();

        //Constructor
        public SuppliersPresenter(ISuppliersView view)
        {
            supplierList = new BindingSource();
            this.view = view;
            this.view.AddEvent += AddMethod;
            this.view.EditEvent += LoadDataToEdit;
            this.view.DeleteEvent += DeleteInventory;
            this.view.SaveEvent += SaveChange;
            this.view.CancelEvent += CancelMethod;
            this.view.GetDataList = supplierList;
            //load all data
            LoadData();
        }

        private void ConnectionModelWithView()
        {
            model.Name = view.SuppliersName;
            model.PhoneNumber = view.SuppliersPhone;
            model.Email = view.SuppliersEmail;
        }

        private void LoadData()
        {
            //Set data in inventoryList from database


            //Get supplier Count


        }



        private void AddMethod(object sender, EventArgs e)
        {
            view.IsEdit = false;
        }

        private void LoadDataToEdit(object sender, EventArgs e)
        {
            view.IsEdit = true;
            model.Id = view.Id;

            //Get current supplier by id 

        }

        private void DeleteInventory(object sender, EventArgs e)
        {
            model.Id = view.Id;

            //delete Inventory
            view.Message = $"{view.SuppliersName} deleted successfully";
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

                        view.Message = $"{view.SuppliersName} Edited Successfully";
                    }
                    else
                    {
                        //Add Category name Method 

                        view.Message = $"{view.SuppliersName} Added Successfully";
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
            view.SuppliersName = "";
            view.SuppliersPhone = "";
            view.SuppliersEmail = "";
        }


        private bool CheckInput()
        {
            if (view.SuppliersName.Trim() == "" || view.SuppliersPhone == "" || view.SuppliersEmail == "")
            {

                return false;
            }

            return true;
        }
    }
}
