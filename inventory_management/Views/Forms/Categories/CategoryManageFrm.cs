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
            txtCategoryName.Text = category.Name;

            okBtn.Click += delegate
            {
                if (!category.isEdit)
                {
                    if (CheckName())
                    {
                        category.Name = txtCategoryName.Text.Trim();
                        category.Save();
                    }
                     else
                       XtraMessageBox.Show("this category name is already exist\nchange name to another name", "Name Already exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (category.isEdit)
                {
                    if (txtCategoryName.Text.Trim() != category.Name)
                    {
                        category.Name = txtCategoryName.Text.Trim();
                        category.Save();
                    }
                    else
                        this.Close();
                }
                
            };

            cancelBtn.Click += delegate
            {
                this.Close();
            };
            this.FormClosing += delegate
            {
                category.Cancel();
            };
        }

        //Check Name is exsiste
        private bool CheckName()
        {

            List<string> categoryNames = category.CategoryList
               .OfType<DataRowView>()
               .Select(x => x[1].ToString())
               .ToList();
            if (categoryNames.Contains(txtCategoryName.Text))
                return false;
            return true;
        }

    }
}