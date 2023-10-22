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
using inventory_management.Views.Forms.Inventories;
using inventory_management.Views.Forms.Customers;
using inventory_management.Views.Forms.Suppliers;

namespace inventory_management
{
    public partial class mainForm : DevExpress.XtraEditors.DirectXForm
    {
        Category category = Category.Instance();
        Inventory inventory = Inventory.Instance();
        Customer customer = Customer.Instance();
        Supplier supplier = Supplier.Instance();
        public mainForm()
        {
            InitializeComponent();
            CategoryManagement();
            InventoryManagement();
            CustomerManagement();
            SuppliersManagement();
        }



        //Inventory Management
        private void InventoryManagement()
        {
            dgvInventory.DataSource = inventory.InventoryList.DataSource;

            //Search
            GetValueBySearch(gridViewInventory);
            //Add
            addInventoryBtn.ItemClick += delegate
            {
                inventory.Add();
            };
            //Edit
            editInventoryBtn.ItemClick += delegate
            {
                inventory.Edit(GetIdToEdit(gridViewInventory));

            };
            //Delete
            deleteInventoryBtn.ItemClick += delegate
            {
                inventory.Delete(GetIdToDelete(gridViewInventory));
            };
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
               category.Add();
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

        //Customer Management
        private void CustomerManagement()
        {
            dgvCustomer.DataSource = customer.CustomersList.DataSource;
            lblCustomersCount.Text = customer.Count;
            lblBestCustomer.Text = customer.Best;
            //Search
            GetValueBySearch(gridViewCustomer);
            //Add
            addInventoryBtn.ItemClick += delegate
            {
                customer.Add();
            };
            //Edit
            editInventoryBtn.ItemClick += delegate
            {
                customer.Edit(GetIdToEdit(gridViewCustomer));

            };
            //Delete
            deleteInventoryBtn.ItemClick += delegate
            {
                customer.Delete(GetIdToDelete(gridViewCustomer));
            };
        }

        //Suppliers Management
        private void SuppliersManagement()
        {
            dgvSuppliers.DataSource = supplier.SuppliersList.DataSource;
            lblSuppliersCount.Text = supplier.Count;

            //Search
            GetValueBySearch(gridViewSuppliers);
            //Add
            addSupplierBtn.ItemClick += delegate
            {
                supplier.Add();
            };
            //Edit
            editSupplierBtn.ItemClick += delegate
            {
                supplier.Edit(GetIdToEdit(gridViewSuppliers));

            };
            //Delete
            deleteSupplierBtn.ItemClick += delegate
            {
                supplier.Delete(GetIdToDelete(gridViewSuppliers));
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
