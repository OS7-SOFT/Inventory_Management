using DevExpress.DashboardWin.Native;
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

namespace inventory_management.Views.Forms.Inventories
{
    public class Inventory : IInventoryView
    {
        NotificationManger notification = NotificationManger.Instance();
        InventoryManageFrm IMF;
        InventoryPresenter inventoryPresenter;

        int id;
        string message;
        bool isSuccessed;
        bool isEdit;

        //fildes 
        public BindingSource InventoryList;
        public List<string> Categories;
        public string Name;
        public string Location;
        public double Capacity;
        public string Category_name;
        public string Count;

        //Constructor
        public Inventory()
        {
            inventoryPresenter = new InventoryPresenter(this);
        }


        //properties
        public int Id { get { return id; } }
        public string InventoryName
        {
            get { return Name; }
            set { Name = value; }
        }
        public string InventoryLocation
        {
            get { return Location; }
            set { Location = value; }
        }
        public double InventoryCapacity
        {
            get { return Capacity; }
            set { Capacity = value; }
        }
        public List<string> CategoryList
        {
            
            set { Categories = value; }
        } 
        public string CategoryName
        {
            get { return Category_name; }
            set { Category_name = value; }
        }
        public string Message { set { message = value; } }
        public bool IsSuccessed { set { isSuccessed = value; } }
        public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value; }
        }
        public BindingSource GetDataList {  set{ InventoryList = value; } }

        //event
        public event EventHandler SaveEvent;
        public event EventHandler AddEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler CancelEvent;

        //----------Methods----------------------------

        //Add
        public void Add()
        {
            AddEvent?.Invoke(this, EventArgs.Empty);
            ShowInventoryManageForm();
        }

        //Edit
        public void Edit(int id)
        {
            if (id != 0)
            {
                this.id = id;
                EditEvent?.Invoke(this, EventArgs.Empty);
                ShowInventoryManageForm();
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
                    notification.SuccessedNotification("Delete Inventory", message, "2653SADFA");
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
                IMF.Close();
                Cancel();
                string title = isEdit == true ? "Edit Inventory" : "Add Inventory";
                notification.SuccessedNotification(title, message, "2653SA1231DFA");
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
        private void ShowInventoryManageForm()
        {
            IMF = new InventoryManageFrm();
            IMF.ShowDialog();
            if (IsEdit)
            {
                IMF.Text = "Edit Inventory";
                IMF.IconOptions.LargeImage = ImageHelper.GetImage($"images/actions/edittask_32x32.png");
            }
            else
            {
                IMF.Text = "Add Inventory";
                IMF.IconOptions.LargeImage = ImageHelper.GetImage($"images/actions/add_32x32.png");
            }


        }

        //Singleton
        private static Inventory Object = null;
        public static Inventory Instance()
        {
            if (Object == null)
                Object = new Inventory();
            return Object;
        }
    }
}
