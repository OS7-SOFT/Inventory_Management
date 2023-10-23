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
            txtQuantity.Value = order.Quantity;
            statusCbx.EditValue = order.Status;
            
            if (order.Products.Count > 0)
                ProductCbx.Properties.Items.AddRange(order.Products);
            else
                ProductCbx.Properties.Items.Add("No there any Product");
            if (order.Customers.Count > 0)
                customerCbx.Properties.Items.AddRange(order.Customers);
            else
                customerCbx.Properties.Items.Add("No there any Customer");
            
            customerCbx.EditValue = order.Customer_name;
            ProductCbx.EditValue = order.Product_name;

            okBtn.Click += delegate
            {
                order.Quantity = (int)txtQuantity.Value; 
                order.Product_name = ProductCbx.EditValue != null ? ProductCbx.EditValue.ToString() : "";
                order.Customer_name = customerCbx.EditValue != null ? customerCbx.EditValue.ToString() : "";
                order.Status = statusCbx.EditValue != null ? statusCbx.EditValue.ToString() : "";
                order.Date = DateTime.Now;
                order.Save();
            };
            cancelBtn.Click += delegate
            {
                this.Close();
                if (this.IsDisposed)
                    order.Cancel();
            };

        }
    }
}