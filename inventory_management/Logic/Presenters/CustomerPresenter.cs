﻿using inventory_management.Models;
using inventory_management.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_management.Logic.Presenters
{
    public class CustomerPresenter
    {
        ICustomerView view;
        BindingSource customerList;

        CustomerModel model = new CustomerModel();

        //Constructor
        public CustomerPresenter(ICustomerView view)
        {
            customerList = new BindingSource();
            this.view = view;
            this.view.AddEvent += AddMethod;
            this.view.EditEvent += LoadDataToEdit;
            this.view.DeleteEvent += DeleteInventory;
            this.view.SaveEvent += SaveChange;
            this.view.CancelEvent += CancelMethod;
            this.view.GetDataList = customerList;
            //load all data
            LoadData();
        }

        private void ConnectionModelWithView()
        {
            model.Name = view.CustomerName;
            model.Phone = view.CustomerPhone;
            model.Email = view.CustomerEmail;
            model.Location = view.CustomerLocation;
        }

        private void LoadData()
        {
            //Set data in inventoryList from database


            //Get Customer Count

            //Get best Customer

        }



        private void AddMethod(object sender, EventArgs e)
        {
            view.IsEdit = false;
        }

        private void LoadDataToEdit(object sender, EventArgs e)
        {
            view.IsEdit = true;
            model.Id = view.Id;

            //Get current Customer by id 

        }

        private void DeleteInventory(object sender, EventArgs e)
        {
            model.Id = view.Id;

            //delete Inventory
            view.Message = "Customer deleted successfully";
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

                        view.Message = "Customer Edited Successfully";
                    }
                    else
                    {
                        //Add Category name Method 

                        view.Message = "Customer Added Successfully";
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
            view.CustomerName = "";
            view.CustomerPhone = "";
            view.CustomerEmail = "";
            view.CustomerLocation = "";
        }


        private bool CheckInput()
        {
            if (view.CustomerName.Trim() == "" || view.CustomerPhone == "" || view.CustomerEmail == "" || view.CustomerLocation =="")
            {

                return false;
            }

            return true;
        }
    }
}