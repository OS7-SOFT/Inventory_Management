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
using inventory_management.Views.Forms.Home;
using inventory_management.Views.Notification;

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
        Home home = Home.Instance();

        public mainForm()
        {
            InitializeComponent();
            CategoryManagement();
            InventoryManagement();
            CustomerManagement();
            SuppliersManagement();
            ProductManagement();
            OrderManagement();
            HomeManagement();
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
            category.CategoryList.DataSourceChanged += delegate
            {
                dgvCategory.DataSource = category.CategoryList.DataSource;
                //Set category Count in label
                lblCategoriesCount.Text = category.CategoryList.Count.ToString();
                RepositoryItemComboBox res = new RepositoryItemComboBox();
                for (int i = 0; i <= 3; i++)
                {
                    
                    var row = gridViewCategory.GetDataRow(i);
                    //var list = row["Inventory Names"].ToString().Split(',').ToList();
                    //if(list.Count > 1)
                    //{
                    //    res.Items.AddRange(list);
                    //    row.SetField("Inventory Names", res);
                    //    gridViewCategory.Columns[2].ColumnEdit = res;
                    //}
                    //else if(list.Count <= 1)
                    //{
                    //}
                    //list.Clear();
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

        private void HomeManagement()
        {
            //load data
            home.LoadData();
            Notify();
            //update data
            UpdateData(homeBtn, home.LoadData);
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
                var notComplete = "";
                var status = Dgv.GetRowCellValue(Dgv.FocusedRowHandle, Dgv.Columns[5]).ToString();
                notComplete = status == "Under proccessing" ? "\nthe state this order not complete yet \nwhen you delete this order the quantity order is back to the inventory ":"";

                var name = Dgv.GetRowCellValue(Dgv.FocusedRowHandle,Dgv.Columns[1]).ToString();
                var result = XtraMessageBox.Show($"Are you sure to delete ${name} ?{notComplete}","checked Delete",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if (result ==  DialogResult.Yes)
                    return Convert.ToInt32(Dgv.GetRowCellValue(Dgv.FocusedRowHandle,Dgv.Columns[0]));
                
            }
            else
                XtraMessageBox.Show("Please Select Row From Grid view !", "Select", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return 0;
        }

        public void Notify()
        {
            List<string> NotFullInventory = ((DataTable)home.FullInventory.DataSource).AsEnumerable()
               .Where(row => Convert.ToInt32(row["Available"]) <= 100) // Condition for "Available" equal to 100
               .Select(row => row["InventoryName"].ToString())
               .ToList();

            List<string> FullInventory = ((DataTable)home.FullInventory.DataSource).AsEnumerable()
              .Where(row => Convert.ToInt32(row["Available"]) == 0) // Condition for "Available" equal to 100
              .Select(row => row["InventoryName"].ToString())
              .ToList();

            List<string> NotExpiredProduct = ((DataTable)home.ExpiredProduct.DataSource).AsEnumerable()
                .Where(row => (DateTime.Now - Convert.ToDateTime(row["ExpirationDate"])).TotalDays <= 60) // Condition for expiration date within 60 days
                .Select(row => row["ProductName"].ToString())
                .ToList();

            List<string> ExpiredProduct = ((DataTable)home.ExpiredProduct.DataSource).AsEnumerable()
                .Where(row => (DateTime.Now - Convert.ToDateTime(row["ExpirationDate"])).TotalDays == 0) // Condition for expiration date within 60 days
                .Select(row => row["ProductName"].ToString())
                .ToList();

            if (NotFullInventory.Count > 0)
            {
                foreach (string item in NotFullInventory)
                {
                    NotificationBox.Instance().CreateNotifiction("The " + item + "Inventory is almost full", "Waring", Color.Orange, NotifictionTable, NotifictionGroupControl);
                }
            }
            if(FullInventory.Count > 0)
            {
                foreach (string item in FullInventory)
                {
                    NotificationBox.Instance().CreateNotifiction("The " + item + "Inventory full", "Waring", Color.Red, NotifictionTable, NotifictionGroupControl);
                }
            }


            if (NotExpiredProduct.Count > 0)
            {
                foreach (string item in NotExpiredProduct)
                {
                    NotificationBox.Instance().CreateNotifiction("The " + item + " is Near reach it expireing date", "Waring", Color.Orange, NotifictionTable, NotifictionGroupControl);
                }
            }
            if (ExpiredProduct.Count > 0)
            {
                foreach (string item in ExpiredProduct)
                {
                    NotificationBox.Instance().CreateNotifiction("The " + item + "Is expired", "Waring", Color.Red, NotifictionTable, NotifictionGroupControl);
                }
            }

        }
    }
}
