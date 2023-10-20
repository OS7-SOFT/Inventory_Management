using inventory_management.Views.Forms.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors;

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
            //Set Data in dataGridView
            dgvCategory.DataSource = category.CategoryList.DataSource;
            //Set Category Count
            lblCategoriesCount.Text = category.Count;

            //Search
            GetValueBySearch(gridViewCategory);
            //Add
            addCategoryBtn.ItemClick += delegate
            {
                MessageBox.Show(gridViewCategory.FindFilterText);
               // category.Add();
            };
            //Edit
            editCategoryBtn.ItemClick += delegate
            {
               category.Edit(GetIdToEdit(gridViewCategory));
                
            };
            //Delete
            deleteCategoryBtn.ItemClick += delegate
            {
                category.Delete(GetIdToDelete(gridViewCategory));
            };


        }

        //Get Search result
        private void GetValueBySearch(GridView gridView)
        {
            int id = int.TryParse(gridView.FindFilterText, out id) ? Convert.ToInt32(gridView.FindFilterText) : 0;
            string name = gridView.FindFilterText;
            if (id !=0)
                gridView.ActiveFilterString = $"[{1}] LIKE '%{id}%'";
            else
                gridView.ActiveFilterString = $"[{1}] LIKE '%{name}%'";
        }

        //Get Id to Edit
        private int GetIdToEdit(GridView Dgv)
        {
            if (Dgv.SelectedRowsCount > 0)
                return Convert.ToInt32(Dgv.GetRowCellValue(Dgv.FocusedRowHandle,Dgv.Columns[0]));
            
            else
                XtraMessageBox.Show("Please Select Row From Grid view !","Select",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return 0;
        }

        //Get Id to Delete
        private int GetIdToDelete(GridView Dgv)
        {
            if (Dgv.SelectedRowsCount > 0)
            {
                var name = Dgv.GetRowCellValue(Dgv.FocusedRowHandle,Dgv.Columns[1]).ToString();
                var result = XtraMessageBox.Show($"Are you sure to delete ${name} ?","checked Delete",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if (result ==  DialogResult.Yes)
                    return Convert.ToInt32(Dgv.GetRowCellValue(Dgv.FocusedRowHandle,Dgv.Columns[0]));
                
            }
            else
                XtraMessageBox.Show("Please Select Row From Grid view !", "Select", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return 0;
        }


    }
}
