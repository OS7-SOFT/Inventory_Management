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
            //select product
            ProductCbx.EditValueChanged += delegate
            {
                if(GetInventory().Count > 0)
                    inventoryCbx.Properties.Items.AddRange(GetInventory());   
            };
            //select inventory
            inventoryCbx.EditValueChanged += delegate
            {
                txtQuantity.Properties.MaxValue = GetProductCountInCurrentInventory();
                txtQuantity.Properties.MinValue = 0;
            };
           
            
            if (order.Products.Count > 0)
                ProductCbx.Properties.Items.AddRange(GetNameProducts());
            if (order.Customers.Count > 0)
                customerCbx.Properties.Items.AddRange(order.Customers);

            txtQuantity.Value = order.Quantity;
            inventoryCbx.EditValue = order.Inventory_id != 0 ? GetInventoryNameById() : null;
            statusCbx.EditValue = order.Status;
            customerCbx.EditValue = order.Customer_name;
            ProductCbx.EditValue = order.Product_name;


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
                        SaveChange();
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
            if (ProductCbx.EditValue.ToString().Trim() == order.Product_name && inventoryCbx.EditValue.ToString().Trim() == GetInventoryNameById() && customerCbx.EditValue.ToString().Trim() == order.Customer_name && txtQuantity.Value == order.Quantity && statusCbx.EditValue.ToString().Trim() == order.Status )
            {
                return false;
            }
            else
                return true;
        }

        //Get ProductCount in current inventory 
        private decimal GetProductCountInCurrentInventory()
        {
            List<object> current = ((DataTable)order.Inventories.DataSource)
              .AsEnumerable()
              .Where(row => row.Field<string>(1) == inventoryCbx.EditValue.ToString())
              .FirstOrDefault().ItemArray.ToList();

            return Convert.ToDecimal(current[2]);
        }
        //Get Inventory names
        private List<string> GetInventory()
        {
            return ((DataTable)order.Inventories.DataSource)
              .AsEnumerable()
              .Where(row => row.Field<string>(3) == ProductCbx.EditValue.ToString())
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
            List<object> current = ((DataTable)order.Inventories.DataSource)
              .AsEnumerable()
              .Where(row => row.Field<int>(0) == order.Inventory_id)
              .FirstOrDefault().ItemArray.ToList();

            return current[1].ToString();
        }

        // Get products name
        private List<string> GetNameProducts()
        {
            return order.Products.OfType<DataRowView>()
                .Select(x => x[0].ToString())
                .ToList();
        }
    }
}