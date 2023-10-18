using inventory_management.Views.Forms.Categories;
using inventory_management.Views.Forms.Notification;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace inventory_management
{
    public partial class mainForm : DevExpress.XtraEditors.DirectXForm
    {
        Category category = Category.Instance();
        NotificationManger notification = NotificationManger.Instance();

        public mainForm()
        {
            InitializeComponent();
            CategoryManagement();
        }



        //Category Management
        private void CategoryManagement()
        {
            //Set Data in dataGridView
            dgvCategory.DataSource = category.SetCategoriesData().DataSource;

            //Add
            addCategoryBtn.ItemClick += delegate
            {
                category.Add();
                notification.AddNotification("Category","Added Successfully", "2154adadasdas");
                
            };
            //Edit
            editCategoryBtn.ItemClick += delegate
            {
         
            };
            //////Delete
            //deleteCategoryBtn.ItemClick += delegate
            //{
            //    category.Delete(GetCurrentId);
            //};


        }
        

    }
}
