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

namespace inventory_management.Views.Forms.Suppliers
{
    public class Supplier : ISuppliersView
    {

        NotificationManger notification = NotificationManger.Instance();
        SuppliersManageFrm SMF;
        SuppliersPresenter suppliersPresenter;

        int id;
        string message;
        bool isSuccessed;
       

        //fildes 
        public BindingSource SuppliersList;
        public string Name;
        public string Phone;
        public string Email;
        public bool isEdit;
        //Constructor
        public Supplier()
        {
            suppliersPresenter = new SuppliersPresenter(this);
        }

        //Properties
        public int Id { get { return id; } }
        public string SuppliersName
        {
            get { return Name; }
            set { Name = value; }
        }
        public string SuppliersPhone
        {
            get { return Phone; }
            set { Phone = value; }
        }
        public string SuppliersEmail
        {
            get { return Email; }
            set { Email = value; }
        }
        public string Message { set { message = value; } }
        public bool IsSuccessed { set { isSuccessed = value; } }
        public bool IsEdit { get { return isEdit; } set { isEdit = value; } }
        public BindingSource GetDataList { set { SuppliersList = value; } }

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
            ShowSuppliersManageForm();
        }

        //Edit
        public void Edit(int id)
        {
            if (id != 0)
            {
                this.id = id;
                EditEvent?.Invoke(this, EventArgs.Empty);
                ShowSuppliersManageForm();
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
                    notification.SuccessedNotification("Delete Suppliers", message, "2653SADFA");
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
                SMF.Close();
                Cancel();
                string title = isEdit == true ? "Edit Suppliers" : "Add Suppliers";
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
        private void ShowSuppliersManageForm()
        {
            SMF = new SuppliersManageFrm();
            SMF.ShowDialog();
            if (IsEdit)
            {
                SMF.Text = "Edit Suppliers";
                SMF.IconOptions.LargeImage = ImageHelper.GetImage($"images/actions/edittask_32x32.png");
            }
            else
            {
                SMF.Text = "Add Suppliers";
                SMF.IconOptions.LargeImage = ImageHelper.GetImage($"images/actions/add_32x32.png");
            }


        }

        //Singleton
        private static Supplier Object = null;
        public static Supplier Instance()
        {
            if (Object == null)
                Object = new Supplier();
            return Object;
        }


    }
}
