using DevExpress.XtraEditors;
using inventory_management.Views.Forms.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_management.Views.Forms
{
    public partial class OrderManageFrm : DevExpress.XtraEditors.XtraForm
    {
        Order order = Order.Instance();
        public OrderManageFrm()
        {
            InitializeComponent();
            PerformedMethod();
        }

        private void PerformedMethod()
        {
            if (order.Products.Count > 0)
            {
                ProductCbx.Properties.Items.AddRange(GetNameProducts());
            }
            if (order.Customers.Count > 0)
                customerCbx.Properties.Items.AddRange(order.Customers);


            GetCurrentDataToEdit();

            //Events
            //select product
            ProductCbx.EditValueChanged += delegate
            {
                inventoryCbx.Clear();
                CheckValueComboBox(ProductCbx);
                if (ProductCbx.EditValue != null ) 
                    inventoryCbx.Properties.Items.AddRange(GetInventory());
                
            };


            //select inventory
            inventoryCbx.EditValueChanged += delegate
            {

                CheckValueComboBox(inventoryCbx);
                if (inventoryCbx.EditValue != null)
                    GetProductCountInCurrentInventory();
                
               
            };

            statusCbx.EditValueChanged += delegate
            {
                CheckValueComboBox(statusCbx);
            };

            customerCbx.EditValueChanged += delegate
            {
                CheckValueComboBox(customerCbx);
            };

            okBtn.Click += delegate
            {   //Add inventory
                if (!order.isEdit)
                {
                    order.Date = DateTime.Now;
                    SaveChange();
                }
                //Edit inventory
                if (order.isEdit)
                {
                    if (CheckValueChanged())
                    {
                        if (inventoryCbx.EditValue == null)
                            XtraMessageBox.Show("All fields is requird", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            SaveChange();
                    }
                    else
                        this.Close();
                }

            };

            //Close form 
            cancelBtn.Click += delegate
            {
                this.Close();
            };
            this.FormClosing += delegate
            {
                order.Cancel();
            };

        }

        //Get Current Data when update
        private void GetCurrentDataToEdit() 
        {
            if (order.isEdit)
            {
                txtQuantity.Value = order.Quantity;
                inventoryCbx.EditValue = GetInventoryNameById();
                statusCbx.EditValue = order.Status;
                customerCbx.EditValue = order.Customer_name;
                ProductCbx.EditValue = order.Product_name;

                GetProductCountInCurrentInventory();
                inventoryCbx.Properties.Items.AddRange(GetInventory());
            }
            
        }

        //save change
        private void SaveChange()
        {
            order.Quantity = (int)txtQuantity.Value;
            order.Product_name = ProductCbx.EditValue != null ? ProductCbx.EditValue.ToString() : "";
            order.Inventory_id = inventoryCbx.EditValue != null ? GetInventoryId() : 0;
            order.Customer_name = customerCbx.EditValue != null ? customerCbx.EditValue.ToString() : "";
            order.Status = statusCbx.EditValue != null ? statusCbx.EditValue.ToString() : "";
            order.Save();
        }

        //check if user is change value
        private bool CheckValueChanged()
        {
            if (ProductCbx.Text.Trim() == order.Product_name  && inventoryCbx.Text.Trim() == GetInventoryNameById() && customerCbx.Text.Trim() == order.Customer_name && txtQuantity.Value == order.Quantity && statusCbx.Text.Trim() == order.Status )
            {
                return false;
            }
         
           return true;
            
        }

        //Get ProductCount in current inventory 
        private void GetProductCountInCurrentInventory()
        {
            var orderQuantity = ((DataTable)order.OrderList.DataSource)
                .AsEnumerable()
                .Where(row => row.Field<string>(2) == inventoryCbx.EditValue.ToString())
                .Select(count => Convert.ToDecimal(count[3])).FirstOrDefault();

            var quantityAvailable = ((DataTable)order.Inventories.DataSource)
                .AsEnumerable()
                .Where(row => row.Field<string>(1) == inventoryCbx.EditValue.ToString())
                .Select(count => Convert.ToDecimal(count[2])).FirstOrDefault();
            //Check if user edit or add order
            txtQuantity.Properties.MinValue = 0;
            txtQuantity.Properties.MaxValue = order.isEdit == true 
                                             ? orderQuantity + quantityAvailable 
                                             : quantityAvailable; 
        }
        //Get Inventory names
        private List<string> GetInventory()
        {
                return ((DataTable)order.Inventories.DataSource)
              .AsEnumerable()
              .Where(row => row.Field<string>(3) == ProductCbx.EditValue.ToString() && row.Field<int>(2) > 0)
              .Select(x => x[1].ToString()).ToList();
            
         
        }
        //Get inventory id 
        private int GetInventoryId()
        {
           
                List<object> current = ((DataTable)order.Inventories.DataSource)
                .AsEnumerable()
                .Where(row => row.Field<string>(1) == inventoryCbx.EditValue.ToString())
                .FirstOrDefault().ItemArray.ToList();
                return Convert.ToInt32(current[0]);
           
        }
        //Get inventory name byid 
        private string GetInventoryNameById()
        {
           return ((DataTable)order.Inventories.DataSource)
                .AsEnumerable()
                .Where(row => row.Field<int>(0) == order.Inventory_id)
                .Select(name => name[1].ToString()).FirstOrDefault();
        }

        // Get products name
        private List<string> GetNameProducts()
        {
            return order.Products.OfType<DataRowView>()
                .Select(x => x[0].ToString())
                .ToList();
        }

        //Check Combobox value
        private void CheckValueComboBox(ComboBoxEdit CB)
        {
            string enteredValue = CB.Text;

            bool isValid = CB.Properties.Items.Contains(enteredValue);

            CB.EditValue = isValid ? enteredValue : null;
        }

    }
}