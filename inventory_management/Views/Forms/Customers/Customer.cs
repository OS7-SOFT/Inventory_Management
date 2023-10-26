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

namespace inventory_management.Views.Forms.Customers
{
    public class Customer : ICustomerView
    {
        NotificationManger notification = NotificationManger.Instance();
        CustomerPresenter customerPresenter;
        CustomersManageFrm  CustomerCF;

        int id;
        string message;
        bool isSuccessed;
        bool isEdit;

        //fildes 
        public BindingSource CustomersList;
        public string Name;
        public string Phone;
        public string Email;
        public string Location;
        public string Best;

        //Constructor
        public Customer()
        {
            customerPresenter = new CustomerPresenter(this);
        }

        //Properties
        public int Id { get { return id; } }
        public string CustomerName
        {
            get { return Name; }
            set { Name = value; }
        } 
        public string CustomerPhone
        {
            get { return Phone; }
            set { Phone = value; }
        } 
        public string CustomerEmail
        {
            get { return Email; }
            set { Email = value; }
        } 
        public string CustomerLocation
        {
            get { return Location; }
            set { Location = value; }
        }
        public string BestCustomer { set { Best = value; } }


        public string Message { set { message = value; } }
        public bool IsSuccessed { set { isSuccessed = value; } }
        public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value; }
        }
        public BindingSource GetDataList { set { CustomersList = value; } }

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
            ShowCustomerManageForm();
        }

        //Edit
        public void Edit(int id)
        {
            if (id != 0)
            {
                this.id = id;
                EditEvent?.Invoke(this, EventArgs.Empty);
                ShowCustomerManageForm();
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
                    notification.SuccessedNotification("Delete Customer", message, "2653SADFA");
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
                CustomerCF.Close();
                Cancel();
                string title = isEdit == true ? "Edit Customer" : "Add Customer";
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
        private void ShowCustomerManageForm()
        {
            CustomerCF = new CustomersManageFrm();
            CustomerCF.ShowDialog();
            if (IsEdit)
            {
                CustomerCF.Text = "Edit Customer";
                CustomerCF.IconOptions.LargeImage = ImageHelper.GetImage($"images/actions/edittask_32x32.png");
            }
            else
            {
                CustomerCF.Text = "Add Customer";
                CustomerCF.IconOptions.LargeImage = ImageHelper.GetImage($"images/actions/add_32x32.png");
            }


        }

        //Singleton
        private static Customer Object = null;
        public static Customer Instance()
        {
            if (Object == null)
                Object = new Customer();
            return Object;
        }
    }
}
