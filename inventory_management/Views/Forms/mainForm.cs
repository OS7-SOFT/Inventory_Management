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
        public mainForm()
        {
            InitializeComponent();
            CategoryManagement();
        }



        //Category Management
        private void CategoryManagement()
        {
            //Add
            addCategoryBtn.ItemClick += delegate
            {
                category.Add();
            };
            ////Edit
            //editCategoryBtn.ItemClick += delegate
            //{
                
            //    category.Edit(GetCurrentId);
            //};
            //////Delete
            //deleteCategoryBtn.ItemClick += delegate
            //{
            //    category.Delete(GetCurrentId);
            //};

            
        }
        //Get Current id 
        //int GetCurrentId()
        //{
        //    int id = Convert.ToInt32(dgvCategory.Focused.ToString());
        //    return id;
        //}

    }
}
