using DevExpress.DashboardWin.Native;
using DevExpress.XtraEditors;
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
        CategoryManageFrm CMF;
        CategoryPresenter categoryPresenter;
        NotificationManger notification = NotificationManger.Instance();

        int id;
        string message;
        bool isSuccessed;

        //fildes 
        public BindingSource CategoryList;
        public List<string> InventoryName;
        public string Name;
        public bool isEdit;

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
        public int Id { get { return id; }}
        public string Message { set { message = value; } }
        public bool IsSuccessed { set { isSuccessed = value; } }
        public bool IsEdit { get { return isEdit; } set { isEdit = value; } }
        public BindingSource GetDataList { set { CategoryList = value; } }
        public List<string> InventoryNamesList { get => InventoryName; set => InventoryName = value; }



        //event
        public event EventHandler SaveEvent;
        public event EventHandler AddEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler CancelEvent;
        public event EventHandler LoadDataEvent;
        //--------------methods-----------------------

        //Load data
        public void LoadData()
        {
            LoadDataEvent?.Invoke(this, EventArgs.Empty);
        }

        //Add
        public void Add()
        {
            
            AddEvent?.Invoke(this, EventArgs.Empty);
            ShowCategoryManageForm();
        }

        //Edit
        public void Edit(int id)
        {
            if(id != 0)
            {
                this.id = id;
                EditEvent?.Invoke(this, EventArgs.Empty);
                ShowCategoryManageForm();
            }
           
        }

        //Delete
        public void Delete(int id)
        {
            if(id != 0)
            {
                this.id = id;
                DeleteEvent?.Invoke(this, EventArgs.Empty);
                if (isSuccessed)
                {
                    notification.SuccessedNotification("Delete Category", message, "2653SADFA");
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
                CMF.Close();
                Cancel();
                string title = isEdit == true ? "Edit Category" : "Add Category";
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

        //open category manage form 
        private void ShowCategoryManageForm()
        {
            CMF = new CategoryManageFrm();
            CMF.ShowDialog();
            if (IsEdit)
            {
                CMF.Text = "Edit Category";
                CMF.IconOptions.LargeImage = ImageHelper.GetImage($"images/actions/edittask_32x32.png");
            }
            else
            {
                CMF.Text = "Add Category";
                CMF.IconOptions.LargeImage = ImageHelper.GetImage($"images/actions/add_32x32.png");
            }

            
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
