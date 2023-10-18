using DevExpress.XtraGrid;
using inventory_management.Logic.Presenters;
using inventory_management.Views.Forms.Notification;
using inventory_management.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_management.Views.Forms.Categories
{
    public class Category : ICategoryView
    {
        int id;
        string message;
        bool isSuccessed;
        bool isEdit;
        BindingSource categoryList;

        //fildes 
        public string Name;


        CategoryPresenter categoryPresenter;

        //Constructor
        public Category()
        {
            categoryPresenter = new CategoryPresenter(this);
        }

        //Propertes
        public string CategoryName
        {
            get { return Name; }
            set { Name = value; }
        }
        public int CategoryId { get { return id; }}
        public string Message { set { message = value; } }
        public bool IsSuccessed { set { isSuccessed = value; } }
        public bool IsEdit { get { return isEdit; } set { isEdit = value; } }
        public BindingSource CategoryList{ set { categoryList = value; } }

        //event
        public event EventHandler SaveEvent;
        public event EventHandler AddEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;

        //--------------methods-----------------------

        //Add
        public void Add()
        {
            AddEvent?.Invoke(this, EventArgs.Empty);
            ShowCategoryManageForm();
        }

        //Edit
        public void Edit(int id)
        {
            this.id = id;
            EditEvent?.Invoke(this, EventArgs.Empty);
            ShowCategoryManageForm();
            
        }

        //Delete
        public void Delete(int id)
        {
            this.id = id;
            DeleteEvent?.Invoke(this, EventArgs.Empty);
        }

        //Save
        public void Save()
        {

            SaveEvent?.Invoke(this, EventArgs.Empty);
            if (isSuccessed)
            {
                CategoryManageFrm.Instance().Close();
                string title = isEdit == true ? "Edit Category" : "Add Category";
                ShowNotification(title, message);
            }
            else
                MessageBox.Show(message,"Error in input",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        //Get data from database
        public BindingSource SetCategoriesData()
        {
            return categoryList;
        }

        //Notification method
        private void ShowNotification(string title, string message)
        {
            NotifayIconSingleton.Instance.NotifyIcon.BalloonTipTitle = title;
            NotifayIconSingleton.Instance.NotifyIcon.BalloonTipText = title;
            NotifayIconSingleton.Instance.NotifyIcon.ShowBalloonTip(3000);

        }

        //open category manage form 
        private void ShowCategoryManageForm()
        {
            if (IsEdit)
            {
                CategoryManageFrm.Instance().Text = "Edit Category";
                //Change icons
            }
            else
            {
                CategoryManageFrm.Instance().Text = "Add Category";
                //Change icons
            }

            CategoryManageFrm.Instance().ShowDialog();
        }

        //Singleton
        private static Category Object = null;
        public static Category Instance()
        {
            if (Object == null)
                Object = new Category();
            return Object;
        }

    }
}
