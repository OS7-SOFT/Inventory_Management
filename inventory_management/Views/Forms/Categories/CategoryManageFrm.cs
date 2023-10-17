using DevExpress.XtraEditors;
using inventory_management.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace inventory_management.Views.Forms.Categories
{
    public partial class CategoryManageFrm : DevExpress.XtraEditors.XtraForm
    {

       static Category category = Category.Instance();

        public CategoryManageFrm()
        {
            InitializeComponent();

            PerformedMethod();
        }

        private void PerformedMethod()
        {
            okBtn.Click += delegate
            {
                category.Name = txtCategoryName.Text.Trim();
                category.Save();
            };

            cancelBtn.Click += delegate
            {
                txtCategoryName.Text = "";
                this.Close();
            };
        }

        //Singleton
        private static CategoryManageFrm Object = null;
        public static CategoryManageFrm Instance()
        {
            if (Object == null)
            {
                Object = new CategoryManageFrm();
               
            }
            return Object;
        }

    }
}