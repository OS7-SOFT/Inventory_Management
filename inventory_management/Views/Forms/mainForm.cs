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
using inventory_management.Views.Forms.Products;
using inventory_management.Views.Forms.Orders;
using DevExpress.XtraTab;
using inventory_management.Views.Forms;
using DevExpress.XtraEditors.Repository;

namespace inventory_management
{
    public partial class mainForm : DevExpress.XtraEditors.DirectXForm
    {
        InventoryInfoForm infoForm;

        Category category = Category.Instance();
        Inventory inventory = Inventory.Instance();
        Customer customer = Customer.Instance();
        Supplier supplier = Supplier.Instance();
        Product product = Product.Instance();
        Order order = Order.Instance();


        public mainForm()
        {
            InitializeComponent();
            CategoryManagement();
            InventoryManagement();
            CustomerManagement();
            SuppliersManagement();
            ProductManagement();
            OrderManagement();
           
        }



        //Inventory Management
        private void InventoryManagement()
        {
            //load inventory Data
            inventory.LoadData(); 
            inventory.InventoryList.ListChanged += delegate
            {
                dgvInventory.DataSource = inventory.InventoryList.DataSource;
            };
            //to update data
            UpdateData(inventoryTab, inventory.LoadData);
    
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
            //Show info current inventory
            gridViewInventory.RowClick += delegate
            {
                int id = Convert.ToInt32(gridViewInventory.GetRowCellValue(gridViewInventory.FocusedRowHandle, gridViewInventory.Columns[0]));
                inventory.GetInfoInventory(id);
                infoForm = new InventoryInfoForm();
                infoForm.ShowDialog();
            };
            //open form
            transformBtn.ItemClick += delegate
            {
                inventory.OpenTransformFrm();
            };
        }

        //Category Management
        private void CategoryManagement()
        {
            //load data
            category.LoadData();
            category.CategoryList.ListChanged += delegate
            {
                dgvCategory.DataSource = category.CategoryList.DataSource;
                //Set category Count in label
                lblCategoriesCount.Text = category.CategoryList.Count.ToString();
                RepositoryItemComboBox res = new RepositoryItemComboBox();
                gridViewCategory.Columns[2].ColumnEdit = res;
                for (int i = 0; i <= gridViewCategory.RowCount; i++ )
                {

                    var row = gridViewCategory.GetDataRow(i);

                    

                }
            };
            //to update data
            UpdateData(categoryTab , category.LoadData);

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

        //Products Management
        private void ProductManagement()
        {
            //to load data
            product.LoadData();
            product.ProductList.ListChanged += delegate
            {
                dgvProducts.DataSource = product.ProductList.DataSource;
                lblProductCounts.Text = product.ProductList.Count.ToString();
            };
            //to update data
            UpdateData(productTab, product.LoadData);

           
            lblProductSold.Text = product.Sold;
            lblProductDefective.Text = product.Defective;

            //Add
            addProductBtn.ItemClick += delegate
            {
                product.Add();
            };
            //Edit
            editProductBtn.ItemClick += delegate
            {
                product.Edit(GetIdToEdit(gridViewProduct));

            };
            //Delete
            deleteProductBtn.ItemClick += delegate
            {
                product.Delete(GetIdToDelete(gridViewProduct));
            };
        }

        //Customer Management
        private void CustomerManagement()
        {
            //to load data
            customer.LoadData();
            customer.CustomersList.ListChanged += delegate
            {
                dgvCustomer.DataSource = customer.CustomersList.DataSource;
                lblCustomersCount.Text = customer.CustomersList.Count.ToString();
            };
            //update data
            UpdateData(customerTab, customer.LoadData);
            
            lblBestCustomer.Text = customer.Best;

            //Add
            addCustomerBtn.ItemClick += delegate
            {
                customer.Add();
            };
            //Edit
            editCustomerBtn.ItemClick += delegate
            {
                customer.Edit(GetIdToEdit(gridViewCustomer));

            };
            //Delete
            deleteCustomerBtn.ItemClick += delegate
            {
                customer.Delete(GetIdToDelete(gridViewCustomer));
            };
        }

        //Suppliers Management
        private void SuppliersManagement()
        {
            //to load data
            supplier.LoadData();    
            supplier.SuppliersList.ListChanged += delegate
            {
                dgvSuppliers.DataSource = supplier.SuppliersList.DataSource;
                lblSuppliersCount.Text = supplier.SuppliersList.Count.ToString();
            };
            //update data
            UpdateData(supplierTab, supplier.LoadData);

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

        //Orders Management
        private void OrderManagement()
        {
            //load data
            order.LoadData();
            order.OrderList.ListChanged += delegate
            {
                dgvOrders.DataSource = order.OrderList.DataSource;
                lblOrderCount.Text = order.OrderList.Count.ToString();
            };
            //update data
            UpdateData(orderTab,order.LoadData);

            lblCurrentOrder.Text = order.Current;
            lblCompleteOrder.Text = order.Complete;
            lblCanceledOrder.Text = order.Canceled;

            //Add
            addOrderBtn.ItemClick += delegate
            {
                order.Add();
            };
            //Edit
            editOrderBtn.ItemClick += delegate
            {
                order.Edit(GetIdToEdit(gridViewOrder));

            };
            //Delete
            deleteOrderBtn.ItemClick += delegate
            {
                order.Delete(GetIdToDelete(gridViewOrder));
            };
        }


        //Update date when open tab
        private void UpdateData(XtraTabPage namePage,Action loadData)
        {
            tabPage.SelectedPageChanged += delegate
            {
                if (tabPage.SelectedTabPage == namePage)
                    loadData();
            };
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
