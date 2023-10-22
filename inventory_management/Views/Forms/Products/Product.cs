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

namespace inventory_management.Views.Forms.Products
{
    public class Product : IProductView
    {

        NotificationManger notification = NotificationManger.Instance();
        ProductManageFrm PMF;
        ProductPresenter productPresenter;

        int id;
        string message;
        bool isSuccessed;
        bool isEdit;

        //fildes 
        public BindingSource ProductList;
        public List<string> Categories;
        public List<string> Suppliers;
        public string Name;
        public int Quantity;
        public decimal Sell;
        public decimal Buy;
        public DateTime Entry;
        public DateTime Expiration;
        public string Category_name;
        public string Supplier_name;
        public string Count;
        public string Sold;
        public string Defective;

        //Constructor
        public Product()
        {
            productPresenter = new ProductPresenter(this);
        }

        //Properties
        public int Id { get { return id; } }
        public string ProductName
        {
            get { return Name; }
            set { Name = value; }
        }
        public int ProductQuantity
        {
            get { return Quantity; }
            set { Quantity = value; }
        }
        public decimal SellPrice
        {
            get { return Sell; }
            set { Sell = value; }
        }
        public decimal BuyPrice
        {
            get { return Buy; }
            set { Buy = value; }
        }
        public DateTime EntryDate
        {
            get { return Entry; }
            set { Entry = value; }
        }
        public DateTime ExpirationDate
        {
            get { return Expiration; }
            set { Expiration = value; }
        }
        public string CategoryName
        {
            get { return Category_name; }
            set { Category_name = value; }
        }
        public string SupplierName
        {
            get { return Supplier_name; }
            set { Supplier_name = value; }
        }
        public List<string> SupplierList { set{ Suppliers = value; } }
        public List<string> CategoryList { set{ Categories = value; } }
        public string ProductCount { set { Count = value; } }
        public string ProductSold { set { Sold = value; } }
        public string ProductDefective { set { Defective = value; } }
        public string Message { set { message = value; } }
        public bool IsSuccessed { set { IsSuccessed = value; } }
        public bool IsEdit 
        {
            get { return isEdit; }
            set { isEdit = value; }
        }
        public BindingSource GetDataList { set { ProductList = value; } }

        //events
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
            ShowProductManageForm();
        }

        //Edit
        public void Edit(int id)
        {
            if (id != 0)
            {
                this.id = id;
                EditEvent?.Invoke(this, EventArgs.Empty);
                ShowProductManageForm();
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
                    notification.SuccessedNotification("Delete Product", message, "2653SADFA");
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
                PMF.Close();
                Cancel();
                string title = isEdit == true ? "Edit Product" : "Add Product";
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
        private void ShowProductManageForm()
        {
            PMF = new ProductManageFrm();
            PMF.ShowDialog();
            if (IsEdit)
            {
                PMF.Text = "Edit Product";
                PMF.IconOptions.LargeImage = ImageHelper.GetImage($"images/actions/edittask_32x32.png");
            }
            else
            {
                PMF.Text = "Add Product";
                PMF.IconOptions.LargeImage = ImageHelper.GetImage($"images/actions/add_32x32.png");
            }


        }

        //Singleton
        private static Product Object = null;
        public static Product Instance()
        {
            if (Object == null)
                Object = new Product();
            return Object;
        }
    }
}
