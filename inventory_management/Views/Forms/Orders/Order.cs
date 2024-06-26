﻿using DevExpress.DashboardWin.Native;
using DevExpress.XtraEditors;
using inventory_management.Logic.Presenters;
using inventory_management.Views.Forms.Notification;
using inventory_management.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_management.Views.Forms.Orders
{
    public class Order : IOrderView
    {
        NotificationManger notification = NotificationManger.Instance();
        OrderManageFrm OMF;
        OrderPresenter orderPresenter;
        int id;
        string message;
        bool isSuccessed;

        //fildes 
        public BindingSource OrderList;
        public BindingSource Products;
        public BindingSource Inventories;
        public List<string> Customers;
        public string Name;
        public int Quantity;
        public decimal Total;
        public DateTime Date;
        public string Status;
        public string Current;
        public string Complete;
        public string Canceled;
        public string Product_name;
        public int Inventory_id;
        public string Customer_name;
        public bool isEdit;

        //Constructor
        public Order()
        {
            orderPresenter = new OrderPresenter(this);
        }

       
        //Properties
        public int Id { get { return id; } }
        public int OrderedQuantity
        {
            get { return Quantity; }
            set { Quantity = value; }
        }
        public DateTime OrderDate { get { return Date; } set { Date = value; } }
        public string DeliveryStatus
        {
            get { return Status; }
            set { Status = value; }
        }
        public string CurrentOrderCount
        {
            get { return Current; }
            set { Current = value; }
        }
        public string CompleteOrderCount
        {
            get { return Complete; }
            set { Complete = value; }
        }
        public string CanceledOrderCount
        {
            get { return Canceled; }
            set { Canceled = value; }
        }
        public List<string> CustomersList 
        {
            set { Customers = value; }
        }
        public string CustomerName
        {
            get { return Customer_name;}
            set { Customer_name = value; }
        }
        public string ProductName
        {
            get { return Product_name;}
            set { Product_name = value; }
        }
        public int InvetoryId
        {
            get { return Inventory_id; }
            set { Inventory_id = value ; }
        }
        public string Message { set { message = value; } }
        public bool IsSuccessed { set { isSuccessed = value; } }
        public bool IsEdit
        {
            set { isEdit = value; }
            get { return isEdit; }
        }
        public BindingSource ProductsList { set { Products = value; } }
        public BindingSource InventoryList { set { Inventories = value; } }
        public BindingSource GetDataList { set { OrderList = value; } }

        //event
        public event EventHandler SaveEvent;
        public event EventHandler AddEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler CancelEvent;
        public event EventHandler LoadDataEvent;


        //----------Methods----------------------------

        //load data
        public void LoadData()
        {
            LoadDataEvent?.Invoke(this, EventArgs.Empty);
        }

        //Add
        public void Add()
        {
            AddEvent?.Invoke(this, EventArgs.Empty);
            ShowOrderManageForm();
        }

        //Edit
        public void Edit(int id)
        {
            if (id != 0)
            {
                this.id = id;
                EditEvent?.Invoke(this, EventArgs.Empty);
                ShowOrderManageForm();
            }

        }

        //Delete
        public void Delete(int id)
        {
            if (id != 0)
            {
                this.id = id;
                DeleteEvent?.Invoke(this, EventArgs.Empty);
                if (isSuccessed)
                {
                    notification.SuccessedNotification("Delete Order", message, "2653SADFA");
                    LoadData();
                }
                else
                    XtraMessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Save
        public void Save()
        {
            SaveEvent?.Invoke(this, EventArgs.Empty);
            if (isSuccessed)
            {
                OMF.Close();
                Cancel();
                string title = isEdit == true ? "Edit Order" : "Add Order";
                notification.SuccessedNotification(title, message, "2653SA1231DFA");
                LoadData();
            }
            else
                XtraMessageBox.Show(message, "Error in input", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Cancel
        public void Cancel()
        {
            CancelEvent?.Invoke(this, EventArgs.Empty);
        }

        //open Inventory manage form 
        private void ShowOrderManageForm()
        {
            OMF = new OrderManageFrm();
            OMF.ShowDialog();
            if (IsEdit)
            {
                OMF.Text = "Edit Order";
                OMF.IconOptions.LargeImage = ImageHelper.GetImage($"images/actions/edittask_32x32.png");
            }
            else
            {
                OMF.Text = "Add order";
                OMF.IconOptions.LargeImage = ImageHelper.GetImage($"images/actions/add_32x32.png");
            }


        }

        //Singleton
        private static Order Object = null;
        public static Order Instance()
        {
            if (Object == null)
                Object = new Order();
            return Object;
        }
    }
}
